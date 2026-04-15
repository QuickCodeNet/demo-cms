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
    public class GetKafkaEventsQuery : IRequest<Response<List<GetKafkaEventsResponseDto>>>
    {
        public GetKafkaEventsQuery()
        {
        }

        public class GetKafkaEventsHandler : IRequestHandler<GetKafkaEventsQuery, Response<List<GetKafkaEventsResponseDto>>>
        {
            private readonly ILogger<GetKafkaEventsHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public GetKafkaEventsHandler(ILogger<GetKafkaEventsHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetKafkaEventsResponseDto>>> Handle(GetKafkaEventsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetKafkaEventsAsync();
                return returnValue.ToResponse();
            }
        }
    }
}