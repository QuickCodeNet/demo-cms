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
    public class GetItemAspNetUserQuery : IRequest<Response<AspNetUserDto>>
    {
        public string Id { get; set; }

        public GetItemAspNetUserQuery(string id)
        {
            this.Id = id;
        }

        public class GetItemAspNetUserHandler : IRequestHandler<GetItemAspNetUserQuery, Response<AspNetUserDto>>
        {
            private readonly ILogger<GetItemAspNetUserHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetItemAspNetUserHandler(ILogger<GetItemAspNetUserHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetUserDto>> Handle(GetItemAspNetUserQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Id);
                return returnValue.ToResponse();
            }
        }
    }
}