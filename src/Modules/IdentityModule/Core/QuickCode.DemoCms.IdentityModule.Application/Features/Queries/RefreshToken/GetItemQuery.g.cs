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
    public class GetItemRefreshTokenQuery : IRequest<Response<RefreshTokenDto>>
    {
        public int Id { get; set; }

        public GetItemRefreshTokenQuery(int id)
        {
            this.Id = id;
        }

        public class GetItemRefreshTokenHandler : IRequestHandler<GetItemRefreshTokenQuery, Response<RefreshTokenDto>>
        {
            private readonly ILogger<GetItemRefreshTokenHandler> _logger;
            private readonly IRefreshTokenRepository _repository;
            public GetItemRefreshTokenHandler(ILogger<GetItemRefreshTokenHandler> logger, IRefreshTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<RefreshTokenDto>> Handle(GetItemRefreshTokenQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Id);
                return returnValue.ToResponse();
            }
        }
    }
}