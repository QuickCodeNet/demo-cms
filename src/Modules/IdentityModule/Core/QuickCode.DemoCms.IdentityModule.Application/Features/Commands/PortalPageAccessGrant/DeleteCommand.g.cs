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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.PortalPageAccessGrant;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.PortalPageAccessGrant
{
    public class DeletePortalPageAccessGrantCommand : IRequest<Response<bool>>
    {
        public PortalPageAccessGrantDto request { get; set; }

        public DeletePortalPageAccessGrantCommand(PortalPageAccessGrantDto request)
        {
            this.request = request;
        }

        public class DeletePortalPageAccessGrantHandler : IRequestHandler<DeletePortalPageAccessGrantCommand, Response<bool>>
        {
            private readonly ILogger<DeletePortalPageAccessGrantHandler> _logger;
            private readonly IPortalPageAccessGrantRepository _repository;
            public DeletePortalPageAccessGrantHandler(ILogger<DeletePortalPageAccessGrantHandler> logger, IPortalPageAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeletePortalPageAccessGrantCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}