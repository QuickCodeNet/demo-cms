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
    public partial class AssetService : IAssetService
    {
        private readonly ILogger<AssetService> _logger;
        private readonly IAssetRepository _repository;
        public AssetService(ILogger<AssetService> logger, IAssetRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<AssetDto>> InsertAsync(AssetDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(AssetDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, AssetDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<AssetDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<AssetDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByFolderResponseDto>>> GetByFolderAsync(int assetFolderId, int? page, int? size)
        {
            var returnValue = await _repository.GetByFolderAsync(assetFolderId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByFilenameResponseDto>>> SearchByFilenameAsync(string assetFilename, int? page, int? size)
        {
            var returnValue = await _repository.SearchByFilenameAsync(assetFilename, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRecentlyUploadedResponseDto>>> GetRecentlyUploadedAsync(int? page, int? size)
        {
            var returnValue = await _repository.GetRecentlyUploadedAsync(page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByKindResponseDto>>> GetByKindAsync(AssetKind assetKind, int? page, int? size)
        {
            var returnValue = await _repository.GetByKindAsync(assetKind, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetAssetsWithoutFolderResponseDto>>> GetAssetsWithoutFolderAsync(int assetFolderId, int? page, int? size)
        {
            var returnValue = await _repository.GetAssetsWithoutFolderAsync(assetFolderId, page, size);
            return returnValue.ToResponse();
        }
    }
}