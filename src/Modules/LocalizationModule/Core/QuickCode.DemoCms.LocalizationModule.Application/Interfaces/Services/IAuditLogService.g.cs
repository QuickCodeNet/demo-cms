using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.LocalizationModule.Domain.Entities;
using QuickCode.DemoCms.LocalizationModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.AuditLog;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Application.Services.AuditLog
{
    public partial interface IAuditLogService
    {
        Task<Response<AuditLogDto>> InsertAsync(AuditLogDto request);
        Task<Response<bool>> DeleteAsync(AuditLogDto request);
        Task<Response<bool>> UpdateAsync(Guid id, AuditLogDto request);
        Task<Response<List<AuditLogDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AuditLogDto>> GetItemAsync(Guid id);
        Task<Response<bool>> DeleteItemAsync(Guid id);
        Task<Response<int>> TotalItemCountAsync();
    }
}