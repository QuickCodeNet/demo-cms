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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.ApiMethodDefinition;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.ApiMethodDefinition
{
    public class TotalCountApiMethodDefinitionQuery : IRequest<Response<int>>
    {
        public TotalCountApiMethodDefinitionQuery()
        {
        }

        public class TotalCountApiMethodDefinitionHandler : IRequestHandler<TotalCountApiMethodDefinitionQuery, Response<int>>
        {
            private readonly ILogger<TotalCountApiMethodDefinitionHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public TotalCountApiMethodDefinitionHandler(ILogger<TotalCountApiMethodDefinitionHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountApiMethodDefinitionQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}