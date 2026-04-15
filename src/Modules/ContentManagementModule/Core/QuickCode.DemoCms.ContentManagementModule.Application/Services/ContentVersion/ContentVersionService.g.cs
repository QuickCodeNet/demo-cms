using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.ContentVersion;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.ContentVersion
{
    public partial class ContentVersionService : IContentVersionService
    {
        private readonly ILogger<ContentVersionService> _logger;
        private readonly IContentVersionRepository _repository;
        public ContentVersionService(ILogger<ContentVersionService> logger, IContentVersionRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ContentVersionDto>> InsertAsync(ContentVersionDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ContentVersionDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ContentVersionDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ContentVersionDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ContentVersionDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetVersionsForContentResponseDto>>> GetVersionsForContentAsync(ContentKind contentVersionContentTypeKind, int contentVersionContentId, int contentVersionTranslationId, int? page, int? size)
        {
            var returnValue = await _repository.GetVersionsForContentAsync(contentVersionContentTypeKind, contentVersionContentId, contentVersionTranslationId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetSpecificVersionResponseDto>> GetSpecificVersionAsync(int contentVersionId)
        {
            var returnValue = await _repository.GetSpecificVersionAsync(contentVersionId);
            return returnValue.ToResponse();
        }
    }
}