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
    public partial interface ILanguageService
    {
        Task<Response<LanguageDto>> InsertAsync(LanguageDto request);
        Task<Response<bool>> DeleteAsync(LanguageDto request);
        Task<Response<bool>> UpdateAsync(int id, LanguageDto request);
        Task<Response<List<LanguageDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<LanguageDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool languageIsActive, int? page, int? size);
        Task<Response<GetDefaultResponseDto>> GetDefaultAsync(bool languageIsDefault, bool languageIsActive);
        Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string languageCode);
        Task<Response<int>> SetDefaultAsync(int languageId, SetDefaultRequestDto updateRequest);
        Task<Response<int>> DeactivateAsync(int languageId, DeactivateRequestDto updateRequest);
    }
}