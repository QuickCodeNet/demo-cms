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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.PortalPageAccessGrant;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.PortalPageAccessGrant
{
    public class DeleteItemPortalPageAccessGrantCommand : IRequest<Response<bool>>
    {
        public string PermissionGroupName { get; set; }
        public string PortalPageDefinitionKey { get; set; }
        public PageActionType PageAction { get; set; }

        public DeleteItemPortalPageAccessGrantCommand(string permissionGroupName, string portalPageDefinitionKey, PageActionType pageAction)
        {
            this.PermissionGroupName = permissionGroupName;
            this.PortalPageDefinitionKey = portalPageDefinitionKey;
            this.PageAction = pageAction;
        }

        public class DeleteItemPortalPageAccessGrantHandler : IRequestHandler<DeleteItemPortalPageAccessGrantCommand, Response<bool>>
        {
            private readonly ILogger<DeleteItemPortalPageAccessGrantHandler> _logger;
            private readonly IPortalPageAccessGrantRepository _repository;
            public DeleteItemPortalPageAccessGrantHandler(ILogger<DeleteItemPortalPageAccessGrantHandler> logger, IPortalPageAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteItemPortalPageAccessGrantCommand request, CancellationToken cancellationToken)
            {
                var deleteItem = await _repository.GetByPkAsync(request.PermissionGroupName, request.PortalPageDefinitionKey, request.PageAction);
                if (deleteItem.Code == 404)
                    return Response<bool>.NotFound();
                var returnValue = await _repository.DeleteAsync(deleteItem.Value);
                return returnValue.ToResponse();
            }
        }
    }
}