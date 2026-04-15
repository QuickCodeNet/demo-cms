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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.ColumnType;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.ColumnType
{
    public class TotalCountColumnTypeQuery : IRequest<Response<int>>
    {
        public TotalCountColumnTypeQuery()
        {
        }

        public class TotalCountColumnTypeHandler : IRequestHandler<TotalCountColumnTypeQuery, Response<int>>
        {
            private readonly ILogger<TotalCountColumnTypeHandler> _logger;
            private readonly IColumnTypeRepository _repository;
            public TotalCountColumnTypeHandler(ILogger<TotalCountColumnTypeHandler> logger, IColumnTypeRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountColumnTypeQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}