using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.PageTranslation;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.PageTranslation
{
    public partial class PageTranslationService : IPageTranslationService
    {
        private readonly ILogger<PageTranslationService> _logger;
        private readonly IPageTranslationRepository _repository;
        public PageTranslationService(ILogger<PageTranslationService> logger, IPageTranslationRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<PageTranslationDto>> InsertAsync(PageTranslationDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(PageTranslationDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, PageTranslationDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<PageTranslationDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<PageTranslationDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByPageIdResponseDto>>> GetByPageIdAsync(int pageTranslationPageId, int? page, int? size)
        {
            var returnValue = await _repository.GetByPageIdAsync(pageTranslationPageId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByPageAndLanguageResponseDto>> GetByPageAndLanguageAsync(int pageTranslationPageId, string pageTranslationLanguageCode)
        {
            var returnValue = await _repository.GetByPageAndLanguageAsync(pageTranslationPageId, pageTranslationLanguageCode);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetBySlugAndLanguageResponseDto>> GetBySlugAndLanguageAsync(string pageTranslationLanguageCode, string pageTranslationSlug)
        {
            var returnValue = await _repository.GetBySlugAndLanguageAsync(pageTranslationLanguageCode, pageTranslationSlug);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> CheckSlugExistsAsync(string pageTranslationLanguageCode, string pageTranslationSlug)
        {
            var returnValue = await _repository.CheckSlugExistsAsync(pageTranslationLanguageCode, pageTranslationSlug);
            return returnValue.ToResponse();
        }
    }
}