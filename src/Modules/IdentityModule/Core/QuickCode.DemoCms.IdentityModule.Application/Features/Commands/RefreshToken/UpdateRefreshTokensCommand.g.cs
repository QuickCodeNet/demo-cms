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
    public class UpdateRefreshTokensCommand : IRequest<Response<int>>
    {
        public string RefreshTokenToken { get; set; }
        public UpdateRefreshTokensRequestDto UpdateRequest { get; set; }

        public UpdateRefreshTokensCommand(string refreshTokenToken, UpdateRefreshTokensRequestDto updateRequest)
        {
            this.RefreshTokenToken = refreshTokenToken;
            this.UpdateRequest = updateRequest;
        }

        public class UpdateRefreshTokensHandler : IRequestHandler<UpdateRefreshTokensCommand, Response<int>>
        {
            private readonly ILogger<UpdateRefreshTokensHandler> _logger;
            private readonly IRefreshTokenRepository _repository;
            public UpdateRefreshTokensHandler(ILogger<UpdateRefreshTokensHandler> logger, IRefreshTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(UpdateRefreshTokensCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.UpdateRefreshTokensAsync(request.RefreshTokenToken, request.UpdateRequest);
                return returnValue.ToResponse();
            }
        }
    }
}