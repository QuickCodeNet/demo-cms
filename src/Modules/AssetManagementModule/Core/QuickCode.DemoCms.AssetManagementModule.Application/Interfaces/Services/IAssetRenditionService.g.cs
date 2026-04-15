using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.AssetManagementModule.Domain.Entities;
using QuickCode.DemoCms.AssetManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.AssetRendition;
using QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.AssetManagementModule.Application.Services.AssetRendition
{
    public partial interface IAssetRenditionService
    {
        Task<Response<AssetRenditionDto>> InsertAsync(AssetRenditionDto request);
        Task<Response<bool>> DeleteAsync(AssetRenditionDto request);
        Task<Response<bool>> UpdateAsync(int id, AssetRenditionDto request);
        Task<Response<List<AssetRenditionDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AssetRenditionDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetRenditionsForAssetResponseDto>>> GetRenditionsForAssetAsync(int assetRenditionOriginalAssetId, int? page, int? size);
        Task<Response<GetRenditionByNameResponseDto>> GetRenditionByNameAsync(int assetRenditionOriginalAssetId, string assetRenditionName);
    }
}