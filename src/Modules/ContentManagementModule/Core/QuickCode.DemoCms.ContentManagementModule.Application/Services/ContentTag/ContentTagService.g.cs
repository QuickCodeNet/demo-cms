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
    public partial class ContentTagService : IContentTagService
    {
        private readonly ILogger<ContentTagService> _logger;
        private readonly IContentTagRepository _repository;
        public ContentTagService(ILogger<ContentTagService> logger, IContentTagRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ContentTagDto>> InsertAsync(ContentTagDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ContentTagDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(ContentKind contentTypeKind, int contentId, int tagId, ContentTagDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.ContentTypeKind, request.ContentId, request.TagId);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ContentTagDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ContentTagDto>> GetItemAsync(ContentKind contentTypeKind, int contentId, int tagId)
        {
            var returnValue = await _repository.GetByPkAsync(contentTypeKind, contentId, tagId);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(ContentKind contentTypeKind, int contentId, int tagId)
        {
            var deleteItem = await _repository.GetByPkAsync(contentTypeKind, contentId, tagId);
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

        public async Task<Response<List<GetTagsForContentResponseDto>>> GetTagsForContentAsync(ContentKind contentTagContentTypeKind, int contentTagContentId)
        {
            var returnValue = await _repository.GetTagsForContentAsync(contentTagContentTypeKind, contentTagContentId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetContentForTagResponseDto>>> GetContentForTagAsync(int contentTagTagId, int? page, int? size)
        {
            var returnValue = await _repository.GetContentForTagAsync(contentTagTagId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RemoveTagFromContentAsync(ContentKind contentTagContentTypeKind, int contentTagContentId, int contentTagTagId)
        {
            var returnValue = await _repository.RemoveTagFromContentAsync(contentTagContentTypeKind, contentTagContentId, contentTagTagId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RemoveAllTagsFromContentAsync(ContentKind contentTagContentTypeKind, int contentTagContentId)
        {
            var returnValue = await _repository.RemoveAllTagsFromContentAsync(contentTagContentTypeKind, contentTagContentId);
            return returnValue.ToResponse();
        }
    }
}