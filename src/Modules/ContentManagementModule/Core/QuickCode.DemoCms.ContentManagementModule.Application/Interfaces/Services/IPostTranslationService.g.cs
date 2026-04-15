using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.PostTranslation;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.PostTranslation
{
    public partial interface IPostTranslationService
    {
        Task<Response<PostTranslationDto>> InsertAsync(PostTranslationDto request);
        Task<Response<bool>> DeleteAsync(PostTranslationDto request);
        Task<Response<bool>> UpdateAsync(int id, PostTranslationDto request);
        Task<Response<List<PostTranslationDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<PostTranslationDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByPostIdResponseDto>>> GetByPostIdAsync(int postTranslationPostId, int? page, int? size);
        Task<Response<GetByPostAndLanguageResponseDto>> GetByPostAndLanguageAsync(int postTranslationPostId, string postTranslationLanguageCode);
        Task<Response<List<SearchPublishedPostsResponseDto>>> SearchPublishedPostsAsync(ContentStatus postsStatus, string postTranslationsLanguageCode, string postTranslationsTitle, int? page, int? size);
    }
}