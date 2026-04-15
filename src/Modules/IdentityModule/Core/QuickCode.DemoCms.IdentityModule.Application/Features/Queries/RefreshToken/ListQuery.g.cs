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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.RefreshToken;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.RefreshToken
{
    public class ListRefreshTokenQuery : IRequest<Response<List<RefreshTokenDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public ListRefreshTokenQuery(int? pageNumber, int? pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

        public class ListRefreshTokenHandler : IRequestHandler<ListRefreshTokenQuery, Response<List<RefreshTokenDto>>>
        {
            private readonly ILogger<ListRefreshTokenHandler> _logger;
            private readonly IRefreshTokenRepository _repository;
            public ListRefreshTokenHandler(ILogger<ListRefreshTokenHandler> logger, IRefreshTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<RefreshTokenDto>>> Handle(ListRefreshTokenQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ListAsync(request.PageNumber, request.PageSize);
                return returnValue.ToResponse();
            }
        }
    }
}