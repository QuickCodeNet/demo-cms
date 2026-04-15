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
    public class GetItemColumnTypeQuery : IRequest<Response<ColumnTypeDto>>
    {
        public int Id { get; set; }

        public GetItemColumnTypeQuery(int id)
        {
            this.Id = id;
        }

        public class GetItemColumnTypeHandler : IRequestHandler<GetItemColumnTypeQuery, Response<ColumnTypeDto>>
        {
            private readonly ILogger<GetItemColumnTypeHandler> _logger;
            private readonly IColumnTypeRepository _repository;
            public GetItemColumnTypeHandler(ILogger<GetItemColumnTypeHandler> logger, IColumnTypeRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<ColumnTypeDto>> Handle(GetItemColumnTypeQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Id);
                return returnValue.ToResponse();
            }
        }
    }
}