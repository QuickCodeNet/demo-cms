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
    public partial interface ILanguageFallbackService
    {
        Task<Response<LanguageFallbackDto>> InsertAsync(LanguageFallbackDto request);
        Task<Response<bool>> DeleteAsync(LanguageFallbackDto request);
        Task<Response<bool>> UpdateAsync(int languageId, int fallbackLanguageId, LanguageFallbackDto request);
        Task<Response<List<LanguageFallbackDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<LanguageFallbackDto>> GetItemAsync(int languageId, int fallbackLanguageId);
        Task<Response<bool>> DeleteItemAsync(int languageId, int fallbackLanguageId);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetFallbacksForLanguageResponseDto>>> GetFallbacksForLanguageAsync(int languageFallbackLanguageId);
        Task<Response<int>> RemoveFallbackAsync(int languageFallbackLanguageId, int languageFallbackFallbackLanguageId);
    }
}