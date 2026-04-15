using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.ContentTag;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.ContentTag
{
    public partial interface IContentTagService
    {
        Task<Response<ContentTagDto>> InsertAsync(ContentTagDto request);
        Task<Response<bool>> DeleteAsync(ContentTagDto request);
        Task<Response<bool>> UpdateAsync(ContentKind contentTypeKind, int contentId, int tagId, ContentTagDto request);
        Task<Response<List<ContentTagDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ContentTagDto>> GetItemAsync(ContentKind contentTypeKind, int contentId, int tagId);
        Task<Response<bool>> DeleteItemAsync(ContentKind contentTypeKind, int contentId, int tagId);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetTagsForContentResponseDto>>> GetTagsForContentAsync(ContentKind contentTagContentTypeKind, int contentTagContentId);
        Task<Response<List<GetContentForTagResponseDto>>> GetContentForTagAsync(int contentTagTagId, int? page, int? size);
        Task<Response<int>> RemoveTagFromContentAsync(ContentKind contentTagContentTypeKind, int contentTagContentId, int contentTagTagId);
        Task<Response<int>> RemoveAllTagsFromContentAsync(ContentKind contentTagContentTypeKind, int contentTagContentId);
    }
}