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
    public class UpdateKafkaEventCommand : IRequest<Response<bool>>
    {
        public string TopicName { get; set; }
        public KafkaEventDto request { get; set; }

        public UpdateKafkaEventCommand(string topicName, KafkaEventDto request)
        {
            this.request = request;
            this.TopicName = topicName;
        }

        public class UpdateKafkaEventHandler : IRequestHandler<UpdateKafkaEventCommand, Response<bool>>
        {
            private readonly ILogger<UpdateKafkaEventHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public UpdateKafkaEventHandler(ILogger<UpdateKafkaEventHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdateKafkaEventCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.TopicName);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}