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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.AuditLog;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.AuditLog
{
    public class UpdateAuditLogCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public AuditLogDto request { get; set; }

        public UpdateAuditLogCommand(Guid id, AuditLogDto request)
        {
            this.request = request;
            this.Id = id;
        }

        public class UpdateAuditLogHandler : IRequestHandler<UpdateAuditLogCommand, Response<bool>>
        {
            private readonly ILogger<UpdateAuditLogHandler> _logger;
            private readonly IAuditLogRepository _repository;
            public UpdateAuditLogHandler(ILogger<UpdateAuditLogHandler> logger, IAuditLogRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdateAuditLogCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.Id);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}