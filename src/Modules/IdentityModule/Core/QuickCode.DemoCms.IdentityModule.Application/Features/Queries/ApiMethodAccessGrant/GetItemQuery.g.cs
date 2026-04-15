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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.ApiMethodAccessGrant;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.ApiMethodAccessGrant
{
    public class GetItemApiMethodAccessGrantQuery : IRequest<Response<ApiMethodAccessGrantDto>>
    {
        public string PermissionGroupName { get; set; }
        public string ApiMethodDefinitionKey { get; set; }

        public GetItemApiMethodAccessGrantQuery(string permissionGroupName, string apiMethodDefinitionKey)
        {
            this.PermissionGroupName = permissionGroupName;
            this.ApiMethodDefinitionKey = apiMethodDefinitionKey;
        }

        public class GetItemApiMethodAccessGrantHandler : IRequestHandler<GetItemApiMethodAccessGrantQuery, Response<ApiMethodAccessGrantDto>>
        {
            private readonly ILogger<GetItemApiMethodAccessGrantHandler> _logger;
            private readonly IApiMethodAccessGrantRepository _repository;
            public GetItemApiMethodAccessGrantHandler(ILogger<GetItemApiMethodAccessGrantHandler> logger, IApiMethodAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<ApiMethodAccessGrantDto>> Handle(GetItemApiMethodAccessGrantQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.PermissionGroupName, request.ApiMethodDefinitionKey);
                return returnValue.ToResponse();
            }
        }
    }
}