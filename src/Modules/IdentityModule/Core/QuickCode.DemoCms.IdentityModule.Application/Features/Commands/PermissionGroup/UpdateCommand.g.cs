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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.PermissionGroup;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.PermissionGroup
{
    public class UpdatePermissionGroupCommand : IRequest<Response<bool>>
    {
        public string Name { get; set; }
        public PermissionGroupDto request { get; set; }

        public UpdatePermissionGroupCommand(string name, PermissionGroupDto request)
        {
            this.request = request;
            this.Name = name;
        }

        public class UpdatePermissionGroupHandler : IRequestHandler<UpdatePermissionGroupCommand, Response<bool>>
        {
            private readonly ILogger<UpdatePermissionGroupHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public UpdatePermissionGroupHandler(ILogger<UpdatePermissionGroupHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdatePermissionGroupCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.Name);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}