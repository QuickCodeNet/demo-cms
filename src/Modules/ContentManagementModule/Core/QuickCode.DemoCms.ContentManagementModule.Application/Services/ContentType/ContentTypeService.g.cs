using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.ContentType;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.ContentType
{
    public partial class ContentTypeService : IContentTypeService
    {
        private readonly ILogger<ContentTypeService> _logger;
        private readonly IContentTypeRepository _repository;
        public ContentTypeService(ILogger<ContentTypeService> logger, IContentTypeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ContentTypeDto>> InsertAsync(ContentTypeDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ContentTypeDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ContentTypeDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ContentTypeDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ContentTypeDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool contentTypeIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(contentTypeIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByKindResponseDto>>> GetByKindAsync(ContentKind contentTypeKind, bool contentTypeIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetByKindAsync(contentTypeKind, contentTypeIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string contentTypeName, bool contentTypeIsActive, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(contentTypeName, contentTypeIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByApiKeyResponseDto>> GetByApiKeyAsync(string contentTypeApiKey)
        {
            var returnValue = await _repository.GetByApiKeyAsync(contentTypeApiKey);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int contentTypeId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(contentTypeId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}