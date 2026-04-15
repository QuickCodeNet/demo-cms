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
    public partial class AssetTranslationService : IAssetTranslationService
    {
        private readonly ILogger<AssetTranslationService> _logger;
        private readonly IAssetTranslationRepository _repository;
        public AssetTranslationService(ILogger<AssetTranslationService> logger, IAssetTranslationRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<AssetTranslationDto>> InsertAsync(AssetTranslationDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(AssetTranslationDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, AssetTranslationDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<AssetTranslationDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<AssetTranslationDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByAssetIdResponseDto>>> GetByAssetIdAsync(int assetTranslationAssetId, int? page, int? size)
        {
            var returnValue = await _repository.GetByAssetIdAsync(assetTranslationAssetId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByAssetAndLanguageResponseDto>> GetByAssetAndLanguageAsync(int assetTranslationAssetId, string assetTranslationLanguageCode)
        {
            var returnValue = await _repository.GetByAssetAndLanguageAsync(assetTranslationAssetId, assetTranslationLanguageCode);
            return returnValue.ToResponse();
        }
    }
}