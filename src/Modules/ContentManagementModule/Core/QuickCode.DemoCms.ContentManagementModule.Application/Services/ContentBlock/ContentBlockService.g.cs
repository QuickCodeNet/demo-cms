using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.ContentBlock;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.ContentBlock
{
    public partial class ContentBlockService : IContentBlockService
    {
        private readonly ILogger<ContentBlockService> _logger;
        private readonly IContentBlockRepository _repository;
        public ContentBlockService(ILogger<ContentBlockService> logger, IContentBlockRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ContentBlockDto>> InsertAsync(ContentBlockDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ContentBlockDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ContentBlockDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ContentBlockDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ContentBlockDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool contentBlockIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(contentBlockIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByKeyResponseDto>> GetByKeyAsync(string contentBlockKey, bool contentBlockIsActive)
        {
            var returnValue = await _repository.GetByKeyAsync(contentBlockKey, contentBlockIsActive);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByKeyResponseDto>>> SearchByKeyAsync(string contentBlockKey, bool contentBlockIsActive, int? page, int? size)
        {
            var returnValue = await _repository.SearchByKeyAsync(contentBlockKey, contentBlockIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int contentBlockId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(contentBlockId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}