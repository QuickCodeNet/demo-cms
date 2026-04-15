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
    public class CleanKafkaEventsWithModelNameCommand : IRequest<Response<int>>
    {
        public string ApiMethodDefinitionsModelName { get; set; }

        public CleanKafkaEventsWithModelNameCommand(string apiMethodDefinitionsModelName)
        {
            this.ApiMethodDefinitionsModelName = apiMethodDefinitionsModelName;
        }

        public class CleanKafkaEventsWithModelNameHandler : IRequestHandler<CleanKafkaEventsWithModelNameCommand, Response<int>>
        {
            private readonly ILogger<CleanKafkaEventsWithModelNameHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public CleanKafkaEventsWithModelNameHandler(ILogger<CleanKafkaEventsWithModelNameHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(CleanKafkaEventsWithModelNameCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CleanKafkaEventsWithModelNameAsync(request.ApiMethodDefinitionsModelName);
                return returnValue.ToResponse();
            }
        }
    }
}