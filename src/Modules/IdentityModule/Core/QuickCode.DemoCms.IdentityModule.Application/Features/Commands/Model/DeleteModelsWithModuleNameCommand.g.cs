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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.Model;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.Model
{
    public class DeleteModelsWithModuleNameCommand : IRequest<Response<int>>
    {
        public string ModelModuleName { get; set; }

        public DeleteModelsWithModuleNameCommand(string modelModuleName)
        {
            this.ModelModuleName = modelModuleName;
        }

        public class DeleteModelsWithModuleNameHandler : IRequestHandler<DeleteModelsWithModuleNameCommand, Response<int>>
        {
            private readonly ILogger<DeleteModelsWithModuleNameHandler> _logger;
            private readonly IModelRepository _repository;
            public DeleteModelsWithModuleNameHandler(ILogger<DeleteModelsWithModuleNameHandler> logger, IModelRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(DeleteModelsWithModuleNameCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.DeleteModelsWithModuleNameAsync(request.ModelModuleName);
                return returnValue.ToResponse();
            }
        }
    }
}