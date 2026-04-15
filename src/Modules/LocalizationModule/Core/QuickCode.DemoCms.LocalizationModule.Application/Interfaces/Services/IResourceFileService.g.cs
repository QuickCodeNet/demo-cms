using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.LocalizationModule.Domain.Entities;
using QuickCode.DemoCms.LocalizationModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.ResourceFile;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Application.Services.ResourceFile
{
    public partial interface IResourceFileService
    {
        Task<Response<ResourceFileDto>> InsertAsync(ResourceFileDto request);
        Task<Response<bool>> DeleteAsync(ResourceFileDto request);
        Task<Response<bool>> UpdateAsync(int id, ResourceFileDto request);
        Task<Response<List<ResourceFileDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ResourceFileDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetPendingImportsResponseDto>>> GetPendingImportsAsync(string resourceFileStatus, int? page, int? size);
        Task<Response<List<GetImportHistoryResponseDto>>> GetImportHistoryAsync(int resourceFileLanguageId, int? page, int? size);
        Task<Response<int>> MarkAsProcessedAsync(int resourceFileId, MarkAsProcessedRequestDto updateRequest);
        Task<Response<int>> MarkAsFailedAsync(int resourceFileId, MarkAsFailedRequestDto updateRequest);
    }
}