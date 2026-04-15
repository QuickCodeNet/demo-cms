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
    public partial class PageService : IPageService
    {
        private readonly ILogger<PageService> _logger;
        private readonly IPageRepository _repository;
        public PageService(ILogger<PageService> logger, IPageRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<PageDto>> InsertAsync(PageDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(PageDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, PageDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<PageDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<PageDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetPublishedResponseDto>>> GetPublishedAsync(ContentStatus pageStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetPublishedAsync(pageStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetDraftsResponseDto>>> GetDraftsAsync(ContentStatus pageStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetDraftsAsync(pageStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetPendingReviewResponseDto>>> GetPendingReviewAsync(ContentStatus pageStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetPendingReviewAsync(pageStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetChildPagesResponseDto>>> GetChildPagesAsync(int pageParentPageId, int? page, int? size)
        {
            var returnValue = await _repository.GetChildPagesAsync(pageParentPageId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> PublishAsync(int pageId, PublishRequestDto updateRequest)
        {
            var returnValue = await _repository.PublishAsync(pageId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ArchiveAsync(int pageId, ArchiveRequestDto updateRequest)
        {
            var returnValue = await _repository.ArchiveAsync(pageId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RevertToDraftAsync(int pageId, RevertToDraftRequestDto updateRequest)
        {
            var returnValue = await _repository.RevertToDraftAsync(pageId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RequestReviewAsync(int pageId, RequestReviewRequestDto updateRequest)
        {
            var returnValue = await _repository.RequestReviewAsync(pageId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}