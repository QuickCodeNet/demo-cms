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
    public class UpdatePortalPageDefinitionCommand : IRequest<Response<bool>>
    {
        public string Key { get; set; }
        public PortalPageDefinitionDto request { get; set; }

        public UpdatePortalPageDefinitionCommand(string key, PortalPageDefinitionDto request)
        {
            this.request = request;
            this.Key = key;
        }

        public class UpdatePortalPageDefinitionHandler : IRequestHandler<UpdatePortalPageDefinitionCommand, Response<bool>>
        {
            private readonly ILogger<UpdatePortalPageDefinitionHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public UpdatePortalPageDefinitionHandler(ILogger<UpdatePortalPageDefinitionHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdatePortalPageDefinitionCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.Key);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}