using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.LocalizationModule.Domain.Entities;
using QuickCode.DemoCms.LocalizationModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.LanguageFallback;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Application.Services.LanguageFallback
{
    public partial class LanguageFallbackService : ILanguageFallbackService
    {
        private readonly ILogger<LanguageFallbackService> _logger;
        private readonly ILanguageFallbackRepository _repository;
        public LanguageFallbackService(ILogger<LanguageFallbackService> logger, ILanguageFallbackRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<LanguageFallbackDto>> InsertAsync(LanguageFallbackDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(LanguageFallbackDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int languageId, int fallbackLanguageId, LanguageFallbackDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.LanguageId, request.FallbackLanguageId);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<LanguageFallbackDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<LanguageFallbackDto>> GetItemAsync(int languageId, int fallbackLanguageId)
        {
            var returnValue = await _repository.GetByPkAsync(languageId, fallbackLanguageId);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int languageId, int fallbackLanguageId)
        {
            var deleteItem = await _repository.GetByPkAsync(languageId, fallbackLanguageId);
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

        public async Task<Response<List<GetFallbacksForLanguageResponseDto>>> GetFallbacksForLanguageAsync(int languageFallbackLanguageId)
        {
            var returnValue = await _repository.GetFallbacksForLanguageAsync(languageFallbackLanguageId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RemoveFallbackAsync(int languageFallbackLanguageId, int languageFallbackFallbackLanguageId)
        {
            var returnValue = await _repository.RemoveFallbackAsync(languageFallbackLanguageId, languageFallbackFallbackLanguageId);
            return returnValue.ToResponse();
        }
    }
}