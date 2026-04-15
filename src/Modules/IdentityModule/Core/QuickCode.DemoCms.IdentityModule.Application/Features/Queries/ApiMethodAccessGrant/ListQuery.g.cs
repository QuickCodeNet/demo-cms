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
    public class ListApiMethodAccessGrantQuery : IRequest<Response<List<ApiMethodAccessGrantDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public ListApiMethodAccessGrantQuery(int? pageNumber, int? pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

        public class ListApiMethodAccessGrantHandler : IRequestHandler<ListApiMethodAccessGrantQuery, Response<List<ApiMethodAccessGrantDto>>>
        {
            private readonly ILogger<ListApiMethodAccessGrantHandler> _logger;
            private readonly IApiMethodAccessGrantRepository _repository;
            public ListApiMethodAccessGrantHandler(ILogger<ListApiMethodAccessGrantHandler> logger, IApiMethodAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<ApiMethodAccessGrantDto>>> Handle(ListApiMethodAccessGrantQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ListAsync(request.PageNumber, request.PageSize);
                return returnValue.ToResponse();
            }
        }
    }
}