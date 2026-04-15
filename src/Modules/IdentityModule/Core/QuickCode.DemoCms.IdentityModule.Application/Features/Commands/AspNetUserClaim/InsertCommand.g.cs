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
    public class InsertAspNetUserClaimCommand : IRequest<Response<AspNetUserClaimDto>>
    {
        public AspNetUserClaimDto request { get; set; }

        public InsertAspNetUserClaimCommand(AspNetUserClaimDto request)
        {
            this.request = request;
        }

        public class InsertAspNetUserClaimHandler : IRequestHandler<InsertAspNetUserClaimCommand, Response<AspNetUserClaimDto>>
        {
            private readonly ILogger<InsertAspNetUserClaimHandler> _logger;
            private readonly IAspNetUserClaimRepository _repository;
            public InsertAspNetUserClaimHandler(ILogger<InsertAspNetUserClaimHandler> logger, IAspNetUserClaimRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetUserClaimDto>> Handle(InsertAspNetUserClaimCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}