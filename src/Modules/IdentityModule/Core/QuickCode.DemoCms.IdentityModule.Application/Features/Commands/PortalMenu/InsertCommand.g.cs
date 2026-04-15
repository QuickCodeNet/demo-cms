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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.PortalMenu;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.PortalMenu
{
    public class InsertPortalMenuCommand : IRequest<Response<PortalMenuDto>>
    {
        public PortalMenuDto request { get; set; }

        public InsertPortalMenuCommand(PortalMenuDto request)
        {
            this.request = request;
        }

        public class InsertPortalMenuHandler : IRequestHandler<InsertPortalMenuCommand, Response<PortalMenuDto>>
        {
            private readonly ILogger<InsertPortalMenuHandler> _logger;
            private readonly IPortalMenuRepository _repository;
            public InsertPortalMenuHandler(ILogger<InsertPortalMenuHandler> logger, IPortalMenuRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<PortalMenuDto>> Handle(InsertPortalMenuCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}