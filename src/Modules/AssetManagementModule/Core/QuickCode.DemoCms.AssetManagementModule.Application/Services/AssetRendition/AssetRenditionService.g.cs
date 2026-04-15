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
    public partial class AssetRenditionService : IAssetRenditionService
    {
        private readonly ILogger<AssetRenditionService> _logger;
        private readonly IAssetRenditionRepository _repository;
        public AssetRenditionService(ILogger<AssetRenditionService> logger, IAssetRenditionRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<AssetRenditionDto>> InsertAsync(AssetRenditionDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(AssetRenditionDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, AssetRenditionDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<AssetRenditionDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<AssetRenditionDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetRenditionsForAssetResponseDto>>> GetRenditionsForAssetAsync(int assetRenditionOriginalAssetId, int? page, int? size)
        {
            var returnValue = await _repository.GetRenditionsForAssetAsync(assetRenditionOriginalAssetId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetRenditionByNameResponseDto>> GetRenditionByNameAsync(int assetRenditionOriginalAssetId, string assetRenditionName)
        {
            var returnValue = await _repository.GetRenditionByNameAsync(assetRenditionOriginalAssetId, assetRenditionName);
            return returnValue.ToResponse();
        }
    }
}