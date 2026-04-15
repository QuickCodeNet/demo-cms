using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.SiteManagementModule.Domain.Entities;
using QuickCode.DemoCms.SiteManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.SiteLanguage;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Application.Services.SiteLanguage
{
    public partial class SiteLanguageService : ISiteLanguageService
    {
        private readonly ILogger<SiteLanguageService> _logger;
        private readonly ISiteLanguageRepository _repository;
        public SiteLanguageService(ILogger<SiteLanguageService> logger, ISiteLanguageRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<SiteLanguageDto>> InsertAsync(SiteLanguageDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(SiteLanguageDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int siteId, int languageId, SiteLanguageDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.SiteId, request.LanguageId);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SiteLanguageDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<SiteLanguageDto>> GetItemAsync(int siteId, int languageId)
        {
            var returnValue = await _repository.GetByPkAsync(siteId, languageId);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int siteId, int languageId)
        {
            var deleteItem = await _repository.GetByPkAsync(siteId, languageId);
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

        public async Task<Response<List<GetLanguagesForSiteResponseDto>>> GetLanguagesForSiteAsync(int siteLanguageSiteId, bool siteLanguageIsEnabled)
        {
            var returnValue = await _repository.GetLanguagesForSiteAsync(siteLanguageSiteId, siteLanguageIsEnabled);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> EnableLanguageAsync(int siteLanguageSiteId, int siteLanguageLanguageId, EnableLanguageRequestDto updateRequest)
        {
            var returnValue = await _repository.EnableLanguageAsync(siteLanguageSiteId, siteLanguageLanguageId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DisableLanguageAsync(int siteLanguageSiteId, int siteLanguageLanguageId, DisableLanguageRequestDto updateRequest)
        {
            var returnValue = await _repository.DisableLanguageAsync(siteLanguageSiteId, siteLanguageLanguageId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}