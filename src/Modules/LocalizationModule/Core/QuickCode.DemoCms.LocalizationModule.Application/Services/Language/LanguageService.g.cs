using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.LocalizationModule.Domain.Entities;
using QuickCode.DemoCms.LocalizationModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.Language;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Application.Services.Language
{
    public partial class LanguageService : ILanguageService
    {
        private readonly ILogger<LanguageService> _logger;
        private readonly ILanguageRepository _repository;
        public LanguageService(ILogger<LanguageService> logger, ILanguageRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<LanguageDto>> InsertAsync(LanguageDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(LanguageDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, LanguageDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<LanguageDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<LanguageDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool languageIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(languageIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetDefaultResponseDto>> GetDefaultAsync(bool languageIsDefault, bool languageIsActive)
        {
            var returnValue = await _repository.GetDefaultAsync(languageIsDefault, languageIsActive);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string languageCode)
        {
            var returnValue = await _repository.GetByCodeAsync(languageCode);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> SetDefaultAsync(int languageId, SetDefaultRequestDto updateRequest)
        {
            var returnValue = await _repository.SetDefaultAsync(languageId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int languageId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(languageId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}