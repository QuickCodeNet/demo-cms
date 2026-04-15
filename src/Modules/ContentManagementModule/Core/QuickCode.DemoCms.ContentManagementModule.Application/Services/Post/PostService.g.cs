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
    public partial class PostService : IPostService
    {
        private readonly ILogger<PostService> _logger;
        private readonly IPostRepository _repository;
        public PostService(ILogger<PostService> logger, IPostRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<PostDto>> InsertAsync(PostDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(PostDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, PostDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<PostDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<PostDto>> GetItemAsync(int id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int id)
        {
            var deleteItem = await _repository.GetByPkAsync(id);
            if (deleteItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.DeleteAsync(deleteItem.Value);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> TotalItemCountAsync()
        {
            var returnValue = await _repository.CountAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetPublishedPostsResponseDto>>> GetPublishedPostsAsync(ContentStatus postStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetPublishedPostsAsync(postStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetPostsByAuthorResponseDto>>> GetPostsByAuthorAsync(int postAuthorId, int? page, int? size)
        {
            var returnValue = await _repository.GetPostsByAuthorAsync(postAuthorId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRecentPostsResponseDto>>> GetRecentPostsAsync(ContentStatus postStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetRecentPostsAsync(postStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> PublishAsync(int postId, PublishRequestDto updateRequest)
        {
            var returnValue = await _repository.PublishAsync(postId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ArchiveAsync(int postId, ArchiveRequestDto updateRequest)
        {
            var returnValue = await _repository.ArchiveAsync(postId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RevertToDraftAsync(int postId, RevertToDraftRequestDto updateRequest)
        {
            var returnValue = await _repository.RevertToDraftAsync(postId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}