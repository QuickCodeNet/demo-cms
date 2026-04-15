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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.AspNetUserRole;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.AspNetUserRole
{
    public class InsertAspNetUserRoleCommand : IRequest<Response<AspNetUserRoleDto>>
    {
        public AspNetUserRoleDto request { get; set; }

        public InsertAspNetUserRoleCommand(AspNetUserRoleDto request)
        {
            this.request = request;
        }

        public class InsertAspNetUserRoleHandler : IRequestHandler<InsertAspNetUserRoleCommand, Response<AspNetUserRoleDto>>
        {
            private readonly ILogger<InsertAspNetUserRoleHandler> _logger;
            private readonly IAspNetUserRoleRepository _repository;
            public InsertAspNetUserRoleHandler(ILogger<InsertAspNetUserRoleHandler> logger, IAspNetUserRoleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetUserRoleDto>> Handle(InsertAspNetUserRoleCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}