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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.Model;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.Model
{
    public class TotalCountModelQuery : IRequest<Response<int>>
    {
        public TotalCountModelQuery()
        {
        }

        public class TotalCountModelHandler : IRequestHandler<TotalCountModelQuery, Response<int>>
        {
            private readonly ILogger<TotalCountModelHandler> _logger;
            private readonly IModelRepository _repository;
            public TotalCountModelHandler(ILogger<TotalCountModelHandler> logger, IModelRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountModelQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}