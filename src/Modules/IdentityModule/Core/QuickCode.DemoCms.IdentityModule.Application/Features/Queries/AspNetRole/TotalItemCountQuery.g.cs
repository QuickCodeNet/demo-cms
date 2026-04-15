using System;
using System.Linq;
using QuickCode.DemoCms.Common.Mediator;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.IdentityModule.Domain.Entities;
using QuickCode.DemoCms.IdentityModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.IdentityModule.Application.Dtos.AspNetRole;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.AspNetRole
{
    public class TotalCountAspNetRoleQuery : IRequest<Response<int>>
    {
        public TotalCountAspNetRoleQuery()
        {
        }

        public class TotalCountAspNetRoleHandler : IRequestHandler<TotalCountAspNetRoleQuery, Response<int>>
        {
            private readonly ILogger<TotalCountAspNetRoleHandler> _logger;
            private readonly IAspNetRoleRepository _repository;
            public TotalCountAspNetRoleHandler(ILogger<TotalCountAspNetRoleHandler> logger, IAspNetRoleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountAspNetRoleQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}