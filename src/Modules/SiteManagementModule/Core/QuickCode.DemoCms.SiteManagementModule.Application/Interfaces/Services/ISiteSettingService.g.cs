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
    public partial interface ISiteSettingService
    {
        Task<Response<SiteSettingDto>> InsertAsync(SiteSettingDto request);
        Task<Response<bool>> DeleteAsync(SiteSettingDto request);
        Task<Response<bool>> UpdateAsync(int id, SiteSettingDto request);
        Task<Response<List<SiteSettingDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<SiteSettingDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetSettingsForSiteResponseDto>>> GetSettingsForSiteAsync(int siteSettingSiteId);
        Task<Response<GetSettingByKeyResponseDto>> GetSettingByKeyAsync(int siteSettingSiteId, string siteSettingKey);
        Task<Response<int>> UpdateValueAsync(int siteSettingSiteId, string siteSettingKey, UpdateValueRequestDto updateRequest);
    }
}