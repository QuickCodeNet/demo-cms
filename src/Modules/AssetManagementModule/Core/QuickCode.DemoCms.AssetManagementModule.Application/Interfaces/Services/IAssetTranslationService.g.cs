using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.AssetManagementModule.Domain.Entities;
using QuickCode.DemoCms.AssetManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.AssetTranslation;
using QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.AssetManagementModule.Application.Services.AssetTranslation
{
    public partial interface IAssetTranslationService
    {
        Task<Response<AssetTranslationDto>> InsertAsync(AssetTranslationDto request);
        Task<Response<bool>> DeleteAsync(AssetTranslationDto request);
        Task<Response<bool>> UpdateAsync(int id, AssetTranslationDto request);
        Task<Response<List<AssetTranslationDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AssetTranslationDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByAssetIdResponseDto>>> GetByAssetIdAsync(int assetTranslationAssetId, int? page, int? size);
        Task<Response<GetByAssetAndLanguageResponseDto>> GetByAssetAndLanguageAsync(int assetTranslationAssetId, string assetTranslationLanguageCode);
    }
}