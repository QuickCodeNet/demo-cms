using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.AssetManagementModule.Domain.Entities;
using QuickCode.DemoCms.AssetManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.AssetMetadata;
using QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.AssetManagementModule.Application.Services.AssetMetadata
{
    public partial interface IAssetMetadataService
    {
        Task<Response<AssetMetadataDto>> InsertAsync(AssetMetadataDto request);
        Task<Response<bool>> DeleteAsync(AssetMetadataDto request);
        Task<Response<bool>> UpdateAsync(int id, AssetMetadataDto request);
        Task<Response<List<AssetMetadataDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AssetMetadataDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetMetadataForAssetResponseDto>>> GetMetadataForAssetAsync(int assetMetadataAssetId);
        Task<Response<List<GetAssetsByMetadataResponseDto>>> GetAssetsByMetadataAsync(string assetMetadataKey, string assetMetadataValue, int? page, int? size);
        Task<Response<int>> UpdateMetadataValueAsync(int assetMetadataAssetId, string assetMetadataKey, UpdateMetadataValueRequestDto updateRequest);
    }
}