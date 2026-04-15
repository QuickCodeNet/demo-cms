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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.PortalPageDefinition;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.PortalPageDefinition
{
    public class GetPortalPageDefinitionsWithModuleNameQuery : IRequest<Response<List<GetPortalPageDefinitionsWithModuleNameResponseDto>>>
    {
        public string PortalPageDefinitionModuleName { get; set; }

        public GetPortalPageDefinitionsWithModuleNameQuery(string portalPageDefinitionModuleName)
        {
            this.PortalPageDefinitionModuleName = portalPageDefinitionModuleName;
        }

        public class GetPortalPageDefinitionsWithModuleNameHandler : IRequestHandler<GetPortalPageDefinitionsWithModuleNameQuery, Response<List<GetPortalPageDefinitionsWithModuleNameResponseDto>>>
        {
            private readonly ILogger<GetPortalPageDefinitionsWithModuleNameHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public GetPortalPageDefinitionsWithModuleNameHandler(ILogger<GetPortalPageDefinitionsWithModuleNameHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetPortalPageDefinitionsWithModuleNameResponseDto>>> Handle(GetPortalPageDefinitionsWithModuleNameQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageDefinitionsWithModuleNameAsync(request.PortalPageDefinitionModuleName);
                return returnValue.ToResponse();
            }
        }
    }
}