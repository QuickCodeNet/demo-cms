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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.Module;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.Module
{
    public class TotalCountModuleQuery : IRequest<Response<int>>
    {
        public TotalCountModuleQuery()
        {
        }

        public class TotalCountModuleHandler : IRequestHandler<TotalCountModuleQuery, Response<int>>
        {
            private readonly ILogger<TotalCountModuleHandler> _logger;
            private readonly IModuleRepository _repository;
            public TotalCountModuleHandler(ILogger<TotalCountModuleHandler> logger, IModuleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountModuleQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}