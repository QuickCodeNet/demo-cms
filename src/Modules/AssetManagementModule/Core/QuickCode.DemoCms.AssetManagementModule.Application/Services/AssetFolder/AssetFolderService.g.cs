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
    public partial class AssetFolderService : IAssetFolderService
    {
        private readonly ILogger<AssetFolderService> _logger;
        private readonly IAssetFolderRepository _repository;
        public AssetFolderService(ILogger<AssetFolderService> logger, IAssetFolderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<AssetFolderDto>> InsertAsync(AssetFolderDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(AssetFolderDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, AssetFolderDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<AssetFolderDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<AssetFolderDto>> GetItemAsync(int id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int id)
        {
            var deleteItem = await _repository.GetByPkAsync(id);
            if (deleteItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.DeleteAsync(deleteItem.Value);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> TotalItemCountAsync()
        {
            var returnValue = await _repository.CountAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRootFoldersResponseDto>>> GetRootFoldersAsync(int assetFolderParentFolderId, int? page, int? size)
        {
            var returnValue = await _repository.GetRootFoldersAsync(assetFolderParentFolderId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetSubfoldersResponseDto>>> GetSubfoldersAsync(int assetFolderParentFolderId, int? page, int? size)
        {
            var returnValue = await _repository.GetSubfoldersAsync(assetFolderParentFolderId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string assetFolderName, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(assetFolderName, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByPathResponseDto>> GetByPathAsync(string assetFolderPath)
        {
            var returnValue = await _repository.GetByPathAsync(assetFolderPath);
            return returnValue.ToResponse();
        }
    }
}