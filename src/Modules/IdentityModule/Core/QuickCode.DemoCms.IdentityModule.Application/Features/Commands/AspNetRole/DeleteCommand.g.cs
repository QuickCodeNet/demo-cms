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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.AspNetRole;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.AspNetRole
{
    public class DeleteAspNetRoleCommand : IRequest<Response<bool>>
    {
        public AspNetRoleDto request { get; set; }

        public DeleteAspNetRoleCommand(AspNetRoleDto request)
        {
            this.request = request;
        }

        public class DeleteAspNetRoleHandler : IRequestHandler<DeleteAspNetRoleCommand, Response<bool>>
        {
            private readonly ILogger<DeleteAspNetRoleHandler> _logger;
            private readonly IAspNetRoleRepository _repository;
            public DeleteAspNetRoleHandler(ILogger<DeleteAspNetRoleHandler> logger, IAspNetRoleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteAspNetRoleCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}