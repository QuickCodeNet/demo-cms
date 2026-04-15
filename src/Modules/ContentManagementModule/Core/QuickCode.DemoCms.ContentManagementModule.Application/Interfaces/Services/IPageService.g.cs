using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.Page;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.Page
{
    public partial interface IPageService
    {
        Task<Response<PageDto>> InsertAsync(PageDto request);
        Task<Response<bool>> DeleteAsync(PageDto request);
        Task<Response<bool>> UpdateAsync(int id, PageDto request);
        Task<Response<List<PageDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<PageDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetPublishedResponseDto>>> GetPublishedAsync(ContentStatus pageStatus, int? page, int? size);
        Task<Response<List<GetDraftsResponseDto>>> GetDraftsAsync(ContentStatus pageStatus, int? page, int? size);
        Task<Response<List<GetPendingReviewResponseDto>>> GetPendingReviewAsync(ContentStatus pageStatus, int? page, int? size);
        Task<Response<List<GetChildPagesResponseDto>>> GetChildPagesAsync(int pageParentPageId, int? page, int? size);
        Task<Response<int>> PublishAsync(int pageId, PublishRequestDto updateRequest);
        Task<Response<int>> ArchiveAsync(int pageId, ArchiveRequestDto updateRequest);
        Task<Response<int>> RevertToDraftAsync(int pageId, RevertToDraftRequestDto updateRequest);
        Task<Response<int>> RequestReviewAsync(int pageId, RequestReviewRequestDto updateRequest);
    }
}