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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.KafkaEvent;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.KafkaEvent
{
    public class TotalCountKafkaEventQuery : IRequest<Response<int>>
    {
        public TotalCountKafkaEventQuery()
        {
        }

        public class TotalCountKafkaEventHandler : IRequestHandler<TotalCountKafkaEventQuery, Response<int>>
        {
            private readonly ILogger<TotalCountKafkaEventHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public TotalCountKafkaEventHandler(ILogger<TotalCountKafkaEventHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountKafkaEventQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}