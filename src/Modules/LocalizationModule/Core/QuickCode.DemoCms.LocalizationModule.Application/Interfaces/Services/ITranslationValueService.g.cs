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
    public partial interface ITranslationValueService
    {
        Task<Response<TranslationValueDto>> InsertAsync(TranslationValueDto request);
        Task<Response<bool>> DeleteAsync(TranslationValueDto request);
        Task<Response<bool>> UpdateAsync(int id, TranslationValueDto request);
        Task<Response<List<TranslationValueDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TranslationValueDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<GetByKeyAndLanguageResponseDto>> GetByKeyAndLanguageAsync(int translationValueKeyId, int translationValueLanguageId);
        Task<Response<List<GetTranslationsForLanguageAndNamespaceResponseDto>>> GetTranslationsForLanguageAndNamespaceAsync(int translationValuesLanguageId, int translationKeysNamespaceId, int? page, int? size);
        Task<Response<int>> BulkUpsertAsync(int translationValueKeyId, int translationValueLanguageId, BulkUpsertRequestDto updateRequest);
    }
}