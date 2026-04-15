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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.AspNetUserToken;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.AspNetUserToken
{
    public class DeleteAspNetUserTokenCommand : IRequest<Response<bool>>
    {
        public AspNetUserTokenDto request { get; set; }

        public DeleteAspNetUserTokenCommand(AspNetUserTokenDto request)
        {
            this.request = request;
        }

        public class DeleteAspNetUserTokenHandler : IRequestHandler<DeleteAspNetUserTokenCommand, Response<bool>>
        {
            private readonly ILogger<DeleteAspNetUserTokenHandler> _logger;
            private readonly IAspNetUserTokenRepository _repository;
            public DeleteAspNetUserTokenHandler(ILogger<DeleteAspNetUserTokenHandler> logger, IAspNetUserTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteAspNetUserTokenCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}