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
    public partial class AssetMetadataService : IAssetMetadataService
    {
        private readonly ILogger<AssetMetadataService> _logger;
        private readonly IAssetMetadataRepository _repository;
        public AssetMetadataService(ILogger<AssetMetadataService> logger, IAssetMetadataRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<AssetMetadataDto>> InsertAsync(AssetMetadataDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(AssetMetadataDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, AssetMetadataDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<AssetMetadataDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<AssetMetadataDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetMetadataForAssetResponseDto>>> GetMetadataForAssetAsync(int assetMetadataAssetId)
        {
            var returnValue = await _repository.GetMetadataForAssetAsync(assetMetadataAssetId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetAssetsByMetadataResponseDto>>> GetAssetsByMetadataAsync(string assetMetadataKey, string assetMetadataValue, int? page, int? size)
        {
            var returnValue = await _repository.GetAssetsByMetadataAsync(assetMetadataKey, assetMetadataValue, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateMetadataValueAsync(int assetMetadataAssetId, string assetMetadataKey, UpdateMetadataValueRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateMetadataValueAsync(assetMetadataAssetId, assetMetadataKey, updateRequest);
            return returnValue.ToResponse();
        }
    }
}