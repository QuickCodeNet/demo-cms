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
using QuickCode.DemoCms.IdentityModule.Application.Dtos.TableComboboxSetting;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.TableComboboxSetting
{
    public class InsertTableComboboxSettingCommand : IRequest<Response<TableComboboxSettingDto>>
    {
        public TableComboboxSettingDto request { get; set; }

        public InsertTableComboboxSettingCommand(TableComboboxSettingDto request)
        {
            this.request = request;
        }

        public class InsertTableComboboxSettingHandler : IRequestHandler<InsertTableComboboxSettingCommand, Response<TableComboboxSettingDto>>
        {
            private readonly ILogger<InsertTableComboboxSettingHandler> _logger;
            private readonly ITableComboboxSettingRepository _repository;
            public InsertTableComboboxSettingHandler(ILogger<InsertTableComboboxSettingHandler> logger, ITableComboboxSettingRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<TableComboboxSettingDto>> Handle(InsertTableComboboxSettingCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}