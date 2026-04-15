using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.AssetManagementModule.Domain.Entities;
using QuickCode.DemoCms.AssetManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.Asset;
using QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.AssetManagementModule.Application.Services.Asset
{
    public partial interface IAssetService
    {
        Task<Response<AssetDto>> InsertAsync(AssetDto request);
        Task<Response<bool>> DeleteAsync(AssetDto request);
        Task<Response<bool>> UpdateAsync(int id, AssetDto request);
        Task<Response<List<AssetDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AssetDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByFolderResponseDto>>> GetByFolderAsync(int assetFolderId, int? page, int? size);
        Task<Response<List<SearchByFilenameResponseDto>>> SearchByFilenameAsync(string assetFilename, int? page, int? size);
        Task<Response<List<GetRecentlyUploadedResponseDto>>> GetRecentlyUploadedAsync(int? page, int? size);
        Task<Response<List<GetByKindResponseDto>>> GetByKindAsync(AssetKind assetKind, int? page, int? size);
        Task<Response<List<GetAssetsWithoutFolderResponseDto>>> GetAssetsWithoutFolderAsync(int assetFolderId, int? page, int? size);
    }
}