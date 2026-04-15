using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.AssetManagementModule.Domain.Entities;
using QuickCode.DemoCms.AssetManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.AssetMetadatum;
using QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.AssetManagementModule.Application.Services.AssetMetadatum
{
    public partial interface IAssetMetadatumService
    {
        Task<Response<AssetMetadatumDto>> InsertAsync(AssetMetadatumDto request);
        Task<Response<bool>> DeleteAsync(AssetMetadatumDto request);
        Task<Response<bool>> UpdateAsync(int id, AssetMetadatumDto request);
        Task<Response<List<AssetMetadatumDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AssetMetadatumDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetMetadataForAssetResponseDto>>> GetMetadataForAssetAsync(int assetMetadatumAssetId);
        Task<Response<List<GetAssetsByMetadataResponseDto>>> GetAssetsByMetadataAsync(string assetMetadatumKey, string assetMetadatumValue, int? page, int? size);
        Task<Response<int>> UpdateMetadataValueAsync(int assetMetadatumAssetId, string assetMetadatumKey, UpdateMetadataValueRequestDto updateRequest);
    }
}