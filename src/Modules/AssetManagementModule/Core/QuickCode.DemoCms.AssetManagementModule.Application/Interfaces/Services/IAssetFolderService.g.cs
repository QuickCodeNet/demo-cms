using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.AssetManagementModule.Domain.Entities;
using QuickCode.DemoCms.AssetManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.AssetFolder;
using QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.AssetManagementModule.Application.Services.AssetFolder
{
    public partial interface IAssetFolderService
    {
        Task<Response<AssetFolderDto>> InsertAsync(AssetFolderDto request);
        Task<Response<bool>> DeleteAsync(AssetFolderDto request);
        Task<Response<bool>> UpdateAsync(int id, AssetFolderDto request);
        Task<Response<List<AssetFolderDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AssetFolderDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetRootFoldersResponseDto>>> GetRootFoldersAsync(int assetFolderParentFolderId, int? page, int? size);
        Task<Response<List<GetSubfoldersResponseDto>>> GetSubfoldersAsync(int assetFolderParentFolderId, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string assetFolderName, int? page, int? size);
        Task<Response<GetByPathResponseDto>> GetByPathAsync(string assetFolderPath);
    }
}