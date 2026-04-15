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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.AspNetUserLogin;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.AspNetUserLogin
{
    public class UpdateAspNetUserLoginCommand : IRequest<Response<bool>>
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public AspNetUserLoginDto request { get; set; }

        public UpdateAspNetUserLoginCommand(string loginProvider, string providerKey, AspNetUserLoginDto request)
        {
            this.request = request;
            this.LoginProvider = loginProvider;
            this.ProviderKey = providerKey;
        }

        public class UpdateAspNetUserLoginHandler : IRequestHandler<UpdateAspNetUserLoginCommand, Response<bool>>
        {
            private readonly ILogger<UpdateAspNetUserLoginHandler> _logger;
            private readonly IAspNetUserLoginRepository _repository;
            public UpdateAspNetUserLoginHandler(ILogger<UpdateAspNetUserLoginHandler> logger, IAspNetUserLoginRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdateAspNetUserLoginCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.LoginProvider, request.ProviderKey);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}