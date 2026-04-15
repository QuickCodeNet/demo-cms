using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.AssetManagementModule.Domain.Entities;
using QuickCode.DemoCms.AssetManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.StorageProvider;
using QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.AssetManagementModule.Application.Services.StorageProvider
{
    public partial interface IStorageProviderService
    {
        Task<Response<StorageProviderDto>> InsertAsync(StorageProviderDto request);
        Task<Response<bool>> DeleteAsync(StorageProviderDto request);
        Task<Response<bool>> UpdateAsync(int id, StorageProviderDto request);
        Task<Response<List<StorageProviderDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<StorageProviderDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool storageProviderIsActive, int? page, int? size);
        Task<Response<GetDefaultResponseDto>> GetDefaultAsync(bool storageProviderIsDefault, bool storageProviderIsActive);
        Task<Response<int>> SetAsDefaultAsync(int storageProviderId, SetAsDefaultRequestDto updateRequest);
        Task<Response<int>> DeactivateAsync(int storageProviderId, DeactivateRequestDto updateRequest);
    }
}