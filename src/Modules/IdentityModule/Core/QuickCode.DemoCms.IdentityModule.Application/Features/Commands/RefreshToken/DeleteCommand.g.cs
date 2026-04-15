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
    public class DeleteRefreshTokenCommand : IRequest<Response<bool>>
    {
        public RefreshTokenDto request { get; set; }

        public DeleteRefreshTokenCommand(RefreshTokenDto request)
        {
            this.request = request;
        }

        public class DeleteRefreshTokenHandler : IRequestHandler<DeleteRefreshTokenCommand, Response<bool>>
        {
            private readonly ILogger<DeleteRefreshTokenHandler> _logger;
            private readonly IRefreshTokenRepository _repository;
            public DeleteRefreshTokenHandler(ILogger<DeleteRefreshTokenHandler> logger, IRefreshTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteRefreshTokenCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}