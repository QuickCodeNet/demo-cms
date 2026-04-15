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
    public class DeletePermissionGroupCommand : IRequest<Response<bool>>
    {
        public PermissionGroupDto request { get; set; }

        public DeletePermissionGroupCommand(PermissionGroupDto request)
        {
            this.request = request;
        }

        public class DeletePermissionGroupHandler : IRequestHandler<DeletePermissionGroupCommand, Response<bool>>
        {
            private readonly ILogger<DeletePermissionGroupHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public DeletePermissionGroupHandler(ILogger<DeletePermissionGroupHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeletePermissionGroupCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}