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
    public class GetItemTableComboboxSettingQuery : IRequest<Response<TableComboboxSettingDto>>
    {
        public string TableName { get; set; }

        public GetItemTableComboboxSettingQuery(string tableName)
        {
            this.TableName = tableName;
        }

        public class GetItemTableComboboxSettingHandler : IRequestHandler<GetItemTableComboboxSettingQuery, Response<TableComboboxSettingDto>>
        {
            private readonly ILogger<GetItemTableComboboxSettingHandler> _logger;
            private readonly ITableComboboxSettingRepository _repository;
            public GetItemTableComboboxSettingHandler(ILogger<GetItemTableComboboxSettingHandler> logger, ITableComboboxSettingRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<TableComboboxSettingDto>> Handle(GetItemTableComboboxSettingQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.TableName);
                return returnValue.ToResponse();
            }
        }
    }
}