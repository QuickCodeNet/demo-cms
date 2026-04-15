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
    public class UpdatePortalMenuCommand : IRequest<Response<bool>>
    {
        public string Key { get; set; }
        public PortalMenuDto request { get; set; }

        public UpdatePortalMenuCommand(string key, PortalMenuDto request)
        {
            this.request = request;
            this.Key = key;
        }

        public class UpdatePortalMenuHandler : IRequestHandler<UpdatePortalMenuCommand, Response<bool>>
        {
            private readonly ILogger<UpdatePortalMenuHandler> _logger;
            private readonly IPortalMenuRepository _repository;
            public UpdatePortalMenuHandler(ILogger<UpdatePortalMenuHandler> logger, IPortalMenuRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdatePortalMenuCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.Key);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}