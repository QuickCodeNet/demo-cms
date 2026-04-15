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
    public class InsertAuditLogCommand : IRequest<Response<AuditLogDto>>
    {
        public AuditLogDto request { get; set; }

        public InsertAuditLogCommand(AuditLogDto request)
        {
            this.request = request;
        }

        public class InsertAuditLogHandler : IRequestHandler<InsertAuditLogCommand, Response<AuditLogDto>>
        {
            private readonly ILogger<InsertAuditLogHandler> _logger;
            private readonly IAuditLogRepository _repository;
            public InsertAuditLogHandler(ILogger<InsertAuditLogHandler> logger, IAuditLogRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AuditLogDto>> Handle(InsertAuditLogCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}