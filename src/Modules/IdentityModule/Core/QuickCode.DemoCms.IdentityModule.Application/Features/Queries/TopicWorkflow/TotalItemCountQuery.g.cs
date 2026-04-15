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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.TopicWorkflow;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.TopicWorkflow
{
    public class TotalCountTopicWorkflowQuery : IRequest<Response<int>>
    {
        public TotalCountTopicWorkflowQuery()
        {
        }

        public class TotalCountTopicWorkflowHandler : IRequestHandler<TotalCountTopicWorkflowQuery, Response<int>>
        {
            private readonly ILogger<TotalCountTopicWorkflowHandler> _logger;
            private readonly ITopicWorkflowRepository _repository;
            public TotalCountTopicWorkflowHandler(ILogger<TotalCountTopicWorkflowHandler> logger, ITopicWorkflowRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountTopicWorkflowQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}