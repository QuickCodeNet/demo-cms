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
    public class InsertKafkaEventCommand : IRequest<Response<KafkaEventDto>>
    {
        public KafkaEventDto request { get; set; }

        public InsertKafkaEventCommand(KafkaEventDto request)
        {
            this.request = request;
        }

        public class InsertKafkaEventHandler : IRequestHandler<InsertKafkaEventCommand, Response<KafkaEventDto>>
        {
            private readonly ILogger<InsertKafkaEventHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public InsertKafkaEventHandler(ILogger<InsertKafkaEventHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<KafkaEventDto>> Handle(InsertKafkaEventCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}