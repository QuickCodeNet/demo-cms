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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.AspNetUserClaim;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.AspNetUserClaim
{
    public class DeleteAspNetUserClaimCommand : IRequest<Response<bool>>
    {
        public AspNetUserClaimDto request { get; set; }

        public DeleteAspNetUserClaimCommand(AspNetUserClaimDto request)
        {
            this.request = request;
        }

        public class DeleteAspNetUserClaimHandler : IRequestHandler<DeleteAspNetUserClaimCommand, Response<bool>>
        {
            private readonly ILogger<DeleteAspNetUserClaimHandler> _logger;
            private readonly IAspNetUserClaimRepository _repository;
            public DeleteAspNetUserClaimHandler(ILogger<DeleteAspNetUserClaimHandler> logger, IAspNetUserClaimRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteAspNetUserClaimCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}