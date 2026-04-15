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
    public class GetItemAspNetUserClaimQuery : IRequest<Response<AspNetUserClaimDto>>
    {
        public int Id { get; set; }

        public GetItemAspNetUserClaimQuery(int id)
        {
            this.Id = id;
        }

        public class GetItemAspNetUserClaimHandler : IRequestHandler<GetItemAspNetUserClaimQuery, Response<AspNetUserClaimDto>>
        {
            private readonly ILogger<GetItemAspNetUserClaimHandler> _logger;
            private readonly IAspNetUserClaimRepository _repository;
            public GetItemAspNetUserClaimHandler(ILogger<GetItemAspNetUserClaimHandler> logger, IAspNetUserClaimRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetUserClaimDto>> Handle(GetItemAspNetUserClaimQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Id);
                return returnValue.ToResponse();
            }
        }
    }
}