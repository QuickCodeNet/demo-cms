using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.LocalizationModule.Domain.Entities;
using QuickCode.DemoCms.LocalizationModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.TranslationKey;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Application.Services.TranslationKey
{
    public partial class TranslationKeyService : ITranslationKeyService
    {
        private readonly ILogger<TranslationKeyService> _logger;
        private readonly ITranslationKeyRepository _repository;
        public TranslationKeyService(ILogger<TranslationKeyService> logger, ITranslationKeyRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<TranslationKeyDto>> InsertAsync(TranslationKeyDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(TranslationKeyDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, TranslationKeyDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<TranslationKeyDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<TranslationKeyDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByNamespaceResponseDto>>> GetByNamespaceAsync(int translationKeyNamespaceId, int? page, int? size)
        {
            var returnValue = await _repository.GetByNamespaceAsync(translationKeyNamespaceId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByKeyResponseDto>>> SearchByKeyAsync(string translationKeyKey, int? page, int? size)
        {
            var returnValue = await _repository.SearchByKeyAsync(translationKeyKey, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetUntranslatedKeysForLanguageResponseDto>>> GetUntranslatedKeysForLanguageAsync(int translationKeyNamespaceId, int? page, int? size)
        {
            var returnValue = await _repository.GetUntranslatedKeysForLanguageAsync(translationKeyNamespaceId, page, size);
            return returnValue.ToResponse();
        }
    }
}