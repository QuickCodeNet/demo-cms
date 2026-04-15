using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.PostTranslation;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.PostTranslation
{
    public partial class PostTranslationService : IPostTranslationService
    {
        private readonly ILogger<PostTranslationService> _logger;
        private readonly IPostTranslationRepository _repository;
        public PostTranslationService(ILogger<PostTranslationService> logger, IPostTranslationRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<PostTranslationDto>> InsertAsync(PostTranslationDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(PostTranslationDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, PostTranslationDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<PostTranslationDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<PostTranslationDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByPostIdResponseDto>>> GetByPostIdAsync(int postTranslationPostId, int? page, int? size)
        {
            var returnValue = await _repository.GetByPostIdAsync(postTranslationPostId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByPostAndLanguageResponseDto>> GetByPostAndLanguageAsync(int postTranslationPostId, string postTranslationLanguageCode)
        {
            var returnValue = await _repository.GetByPostAndLanguageAsync(postTranslationPostId, postTranslationLanguageCode);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchPublishedPostsResponseDto>>> SearchPublishedPostsAsync(ContentStatus postsStatus, string postTranslationsLanguageCode, string postTranslationsTitle, int? page, int? size)
        {
            var returnValue = await _repository.SearchPublishedPostsAsync(postsStatus, postTranslationsLanguageCode, postTranslationsTitle, page, size);
            return returnValue.ToResponse();
        }
    }
}