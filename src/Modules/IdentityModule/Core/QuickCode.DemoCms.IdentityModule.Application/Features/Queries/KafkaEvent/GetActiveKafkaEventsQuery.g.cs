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
    public class GetActiveKafkaEventsQuery : IRequest<Response<List<GetActiveKafkaEventsResponseDto>>>
    {
        public bool KafkaEventsIsActive { get; set; }

        public GetActiveKafkaEventsQuery(bool kafkaEventsIsActive)
        {
            this.KafkaEventsIsActive = kafkaEventsIsActive;
        }

        public class GetActiveKafkaEventsHandler : IRequestHandler<GetActiveKafkaEventsQuery, Response<List<GetActiveKafkaEventsResponseDto>>>
        {
            private readonly ILogger<GetActiveKafkaEventsHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public GetActiveKafkaEventsHandler(ILogger<GetActiveKafkaEventsHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetActiveKafkaEventsResponseDto>>> Handle(GetActiveKafkaEventsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetActiveKafkaEventsAsync(request.KafkaEventsIsActive);
                return returnValue.ToResponse();
            }
        }
    }
}