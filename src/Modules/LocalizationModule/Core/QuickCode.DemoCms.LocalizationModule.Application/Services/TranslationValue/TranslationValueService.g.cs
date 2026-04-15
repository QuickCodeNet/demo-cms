using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.LocalizationModule.Domain.Entities;
using QuickCode.DemoCms.LocalizationModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.TranslationValue;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Application.Services.TranslationValue
{
    public partial class TranslationValueService : ITranslationValueService
    {
        private readonly ILogger<TranslationValueService> _logger;
        private readonly ITranslationValueRepository _repository;
        public TranslationValueService(ILogger<TranslationValueService> logger, ITranslationValueRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<TranslationValueDto>> InsertAsync(TranslationValueDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(TranslationValueDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, TranslationValueDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<TranslationValueDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<TranslationValueDto>> GetItemAsync(int id)
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

        public async Task<Response<GetByKeyAndLanguageResponseDto>> GetByKeyAndLanguageAsync(int translationValueKeyId, int translationValueLanguageId)
        {
            var returnValue = await _repository.GetByKeyAndLanguageAsync(translationValueKeyId, translationValueLanguageId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetTranslationsForLanguageAndNamespaceResponseDto>>> GetTranslationsForLanguageAndNamespaceAsync(int translationValuesLanguageId, int translationKeysNamespaceId, int? page, int? size)
        {
            var returnValue = await _repository.GetTranslationsForLanguageAndNamespaceAsync(translationValuesLanguageId, translationKeysNamespaceId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> BulkUpsertAsync(int translationValueKeyId, int translationValueLanguageId, BulkUpsertRequestDto updateRequest)
        {
            var returnValue = await _repository.BulkUpsertAsync(translationValueKeyId, translationValueLanguageId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}