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
    public class DeleteItemAspNetUserClaimCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }

        public DeleteItemAspNetUserClaimCommand(int id)
        {
            this.Id = id;
        }

        public class DeleteItemAspNetUserClaimHandler : IRequestHandler<DeleteItemAspNetUserClaimCommand, Response<bool>>
        {
            private readonly ILogger<DeleteItemAspNetUserClaimHandler> _logger;
            private readonly IAspNetUserClaimRepository _repository;
            public DeleteItemAspNetUserClaimHandler(ILogger<DeleteItemAspNetUserClaimHandler> logger, IAspNetUserClaimRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteItemAspNetUserClaimCommand request, CancellationToken cancellationToken)
            {
                var deleteItem = await _repository.GetByPkAsync(request.Id);
                if (deleteItem.Code == 404)
                    return Response<bool>.NotFound();
                var returnValue = await _repository.DeleteAsync(deleteItem.Value);
                return returnValue.ToResponse();
            }
        }
    }
}