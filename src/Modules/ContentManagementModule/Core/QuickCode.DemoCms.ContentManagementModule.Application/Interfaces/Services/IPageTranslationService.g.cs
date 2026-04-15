using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.PageTranslation;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.PageTranslation
{
    public partial interface IPageTranslationService
    {
        Task<Response<PageTranslationDto>> InsertAsync(PageTranslationDto request);
        Task<Response<bool>> DeleteAsync(PageTranslationDto request);
        Task<Response<bool>> UpdateAsync(int id, PageTranslationDto request);
        Task<Response<List<PageTranslationDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<PageTranslationDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByPageIdResponseDto>>> GetByPageIdAsync(int pageTranslationPageId, int? page, int? size);
        Task<Response<GetByPageAndLanguageResponseDto>> GetByPageAndLanguageAsync(int pageTranslationPageId, string pageTranslationLanguageCode);
        Task<Response<GetBySlugAndLanguageResponseDto>> GetBySlugAndLanguageAsync(string pageTranslationLanguageCode, string pageTranslationSlug);
        Task<Response<bool>> CheckSlugExistsAsync(string pageTranslationLanguageCode, string pageTranslationSlug);
    }
}