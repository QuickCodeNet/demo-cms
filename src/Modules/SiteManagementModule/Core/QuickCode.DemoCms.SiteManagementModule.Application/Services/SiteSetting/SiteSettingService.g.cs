using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.SiteManagementModule.Domain.Entities;
using QuickCode.DemoCms.SiteManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.SiteSetting;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Application.Services.SiteSetting
{
    public partial class SiteSettingService : ISiteSettingService
    {
        private readonly ILogger<SiteSettingService> _logger;
        private readonly ISiteSettingRepository _repository;
        public SiteSettingService(ILogger<SiteSettingService> logger, ISiteSettingRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<SiteSettingDto>> InsertAsync(SiteSettingDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(SiteSettingDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, SiteSettingDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SiteSettingDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<SiteSettingDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetSettingsForSiteResponseDto>>> GetSettingsForSiteAsync(int siteSettingSiteId)
        {
            var returnValue = await _repository.GetSettingsForSiteAsync(siteSettingSiteId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetSettingByKeyResponseDto>> GetSettingByKeyAsync(int siteSettingSiteId, string siteSettingKey)
        {
            var returnValue = await _repository.GetSettingByKeyAsync(siteSettingSiteId, siteSettingKey);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateValueAsync(int siteSettingSiteId, string siteSettingKey, UpdateValueRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateValueAsync(siteSettingSiteId, siteSettingKey, updateRequest);
            return returnValue.ToResponse();
        }
    }
}