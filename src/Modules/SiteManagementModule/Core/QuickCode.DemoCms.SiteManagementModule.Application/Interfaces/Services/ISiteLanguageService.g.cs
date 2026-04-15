using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.SiteManagementModule.Domain.Entities;
using QuickCode.DemoCms.SiteManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.SiteLanguage;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Application.Services.SiteLanguage
{
    public partial interface ISiteLanguageService
    {
        Task<Response<SiteLanguageDto>> InsertAsync(SiteLanguageDto request);
        Task<Response<bool>> DeleteAsync(SiteLanguageDto request);
        Task<Response<bool>> UpdateAsync(int siteId, int languageId, SiteLanguageDto request);
        Task<Response<List<SiteLanguageDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<SiteLanguageDto>> GetItemAsync(int siteId, int languageId);
        Task<Response<bool>> DeleteItemAsync(int siteId, int languageId);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetLanguagesForSiteResponseDto>>> GetLanguagesForSiteAsync(int siteLanguageSiteId, bool siteLanguageIsEnabled);
        Task<Response<int>> EnableLanguageAsync(int siteLanguageSiteId, int siteLanguageLanguageId, EnableLanguageRequestDto updateRequest);
        Task<Response<int>> DisableLanguageAsync(int siteLanguageSiteId, int siteLanguageLanguageId, DisableLanguageRequestDto updateRequest);
    }
}