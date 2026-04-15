using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.Post;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.Post
{
    public partial interface IPostService
    {
        Task<Response<PostDto>> InsertAsync(PostDto request);
        Task<Response<bool>> DeleteAsync(PostDto request);
        Task<Response<bool>> UpdateAsync(int id, PostDto request);
        Task<Response<List<PostDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<PostDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetPublishedPostsResponseDto>>> GetPublishedPostsAsync(ContentStatus postStatus, int? page, int? size);
        Task<Response<List<GetPostsByAuthorResponseDto>>> GetPostsByAuthorAsync(int postAuthorId, int? page, int? size);
        Task<Response<List<GetRecentPostsResponseDto>>> GetRecentPostsAsync(ContentStatus postStatus, int? page, int? size);
        Task<Response<int>> PublishAsync(int postId, PublishRequestDto updateRequest);
        Task<Response<int>> ArchiveAsync(int postId, ArchiveRequestDto updateRequest);
        Task<Response<int>> RevertToDraftAsync(int postId, RevertToDraftRequestDto updateRequest);
    }
}