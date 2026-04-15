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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.AspNetUser;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.AspNetUser
{
    public class UpdateAspNetUserCommand : IRequest<Response<bool>>
    {
        public string Id { get; set; }
        public AspNetUserDto request { get; set; }

        public UpdateAspNetUserCommand(string id, AspNetUserDto request)
        {
            this.request = request;
            this.Id = id;
        }

        public class UpdateAspNetUserHandler : IRequestHandler<UpdateAspNetUserCommand, Response<bool>>
        {
            private readonly ILogger<UpdateAspNetUserHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public UpdateAspNetUserHandler(ILogger<UpdateAspNetUserHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdateAspNetUserCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.Id);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}