using System;
using System.Linq;
using QuickCode.DemoCms.Common.Mediator;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Humanizer;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.IdentityModule.Application.Models;
using QuickCode.DemoCms.IdentityModule.Domain.Entities;
using QuickCode.DemoCms.IdentityModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.IdentityModule.Application.Dtos;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.Queries.PortalPageAccessGrant
{
    public class PortalPageAccessGrantGetItemsQuery : IRequest<Response<PortalPageAccessGrantList>>
    {
        private string PermissionGroupName { get; set; }

        public PortalPageAccessGrantGetItemsQuery(string permissionGroupName)
        {
            this.PermissionGroupName = permissionGroupName;
        }

        public class PortalPageAccessGrantGetItemsHandler : IRequestHandler<PortalPageAccessGrantGetItemsQuery, Response<PortalPageAccessGrantList>>
        {
            private readonly ILogger<PortalPageAccessGrantGetItemsHandler> _logger;
            private readonly IPortalPageAccessGrantRepository _portalPermissionAccessRepository; 
            private readonly IPortalPageDefinitionRepository _portalPageDefinitionRepository;
            
            public PortalPageAccessGrantGetItemsHandler(ILogger<PortalPageAccessGrantGetItemsHandler> logger, 
                IPortalPageAccessGrantRepository portalPermissionAccessRepository,
                IPortalPageDefinitionRepository portalPageDefinitionRepository)
            {
                _logger = logger;
                _portalPermissionAccessRepository = portalPermissionAccessRepository;
                _portalPageDefinitionRepository= portalPageDefinitionRepository;
            }

            public async Task<Response<PortalPageAccessGrantList>> Handle(PortalPageAccessGrantGetItemsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = new Response<PortalPageAccessGrantList>
                {
                    Value = new PortalPageAccessGrantList
                    {
                        PermissionGroupName = request.PermissionGroupName,
                        PortalPageDefinitions = []
                    }
                };

                var permissionTypes = Enum.GetValues<PageActionType>();
                var permissions = (await _portalPageDefinitionRepository.ListAsync()).Value;
                var permissionAccessData = (await _portalPermissionAccessRepository.GetPortalPageAccessGrantsAsync(request.PermissionGroupName)).Value;
                foreach (var portalPermission in permissions.Where(i=>i.PageAction.Equals(PageActionType.List)).OrderBy(i=>i.Key))
                {
                    if (portalPermission.ModelName.Pluralize().Equals("AuditLogs"))
                    {
                        continue;
                    }
                    
                    var permissionName = $"{portalPermission.ModuleName}{portalPermission.ModelName}";
                    var item = new PortalPagePermissionItem()
                    {
                        PortalPagePermissionName = permissionName,
                        ModelName = portalPermission.ModelName,
                        ModuleName =  portalPermission.ModuleName,
                        PortalPagePermissionTypes = []
                    };

                    foreach (var type in permissionTypes)
                    {
                        var typeItem = new PortalPagePermissionTypeItem()
                        {
                            PortalPagePermissionType = type
                        };

                        var result = permissionAccessData!.Where(i =>
                            i.IsActive &&
                            i.PortalPageDefinitionKey.Equals($"{permissionName}{type}"));

                        typeItem.Value = result.Any();
                        item.PortalPagePermissionTypes.Add(typeItem);
                    }

                    returnValue.Value.PortalPageDefinitions.Add(item);
                }

                return returnValue;
            }
        }
    }
}
