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
    public partial interface ITranslationKeyService
    {
        Task<Response<TranslationKeyDto>> InsertAsync(TranslationKeyDto request);
        Task<Response<bool>> DeleteAsync(TranslationKeyDto request);
        Task<Response<bool>> UpdateAsync(int id, TranslationKeyDto request);
        Task<Response<List<TranslationKeyDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TranslationKeyDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByNamespaceResponseDto>>> GetByNamespaceAsync(int translationKeyNamespaceId, int? page, int? size);
        Task<Response<List<SearchByKeyResponseDto>>> SearchByKeyAsync(string translationKeyKey, int? page, int? size);
        Task<Response<List<GetUntranslatedKeysForLanguageResponseDto>>> GetUntranslatedKeysForLanguageAsync(int translationKeyNamespaceId, int? page, int? size);
    }
}