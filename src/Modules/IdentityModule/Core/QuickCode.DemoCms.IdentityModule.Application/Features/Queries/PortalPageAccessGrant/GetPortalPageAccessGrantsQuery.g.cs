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
    public class GetPortalPageAccessGrantsQuery : IRequest<Response<List<GetPortalPageAccessGrantsResponseDto>>>
    {
        public string PortalPageAccessGrantPermissionGroupName { get; set; }

        public GetPortalPageAccessGrantsQuery(string portalPageAccessGrantPermissionGroupName)
        {
            this.PortalPageAccessGrantPermissionGroupName = portalPageAccessGrantPermissionGroupName;
        }

        public class GetPortalPageAccessGrantsHandler : IRequestHandler<GetPortalPageAccessGrantsQuery, Response<List<GetPortalPageAccessGrantsResponseDto>>>
        {
            private readonly ILogger<GetPortalPageAccessGrantsHandler> _logger;
            private readonly IPortalPageAccessGrantRepository _repository;
            public GetPortalPageAccessGrantsHandler(ILogger<GetPortalPageAccessGrantsHandler> logger, IPortalPageAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetPortalPageAccessGrantsResponseDto>>> Handle(GetPortalPageAccessGrantsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageAccessGrantsAsync(request.PortalPageAccessGrantPermissionGroupName);
                return returnValue.ToResponse();
            }
        }
    }
}