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
    public partial class AssetMetadatumService : IAssetMetadatumService
    {
        private readonly ILogger<AssetMetadatumService> _logger;
        private readonly IAssetMetadatumRepository _repository;
        public AssetMetadatumService(ILogger<AssetMetadatumService> logger, IAssetMetadatumRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<AssetMetadatumDto>> InsertAsync(AssetMetadatumDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(AssetMetadatumDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, AssetMetadatumDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<AssetMetadatumDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<AssetMetadatumDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetMetadataForAssetResponseDto>>> GetMetadataForAssetAsync(int assetMetadatumAssetId)
        {
            var returnValue = await _repository.GetMetadataForAssetAsync(assetMetadatumAssetId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetAssetsByMetadataResponseDto>>> GetAssetsByMetadataAsync(string assetMetadatumKey, string assetMetadatumValue, int? page, int? size)
        {
            var returnValue = await _repository.GetAssetsByMetadataAsync(assetMetadatumKey, assetMetadatumValue, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateMetadataValueAsync(int assetMetadatumAssetId, string assetMetadatumKey, UpdateMetadataValueRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateMetadataValueAsync(assetMetadatumAssetId, assetMetadatumKey, updateRequest);
            return returnValue.ToResponse();
        }
    }
}