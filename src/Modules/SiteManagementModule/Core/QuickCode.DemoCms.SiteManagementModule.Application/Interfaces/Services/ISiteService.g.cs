using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.SiteManagementModule.Domain.Entities;
using QuickCode.DemoCms.SiteManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.Site;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Application.Services.Site
{
    public partial interface ISiteService
    {
        Task<Response<SiteDto>> InsertAsync(SiteDto request);
        Task<Response<bool>> DeleteAsync(SiteDto request);
        Task<Response<bool>> UpdateAsync(int id, SiteDto request);
        Task<Response<List<SiteDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<SiteDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool siteIsActive, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string siteName, int? page, int? size);
        Task<Response<int>> DeactivateAsync(int siteId, DeactivateRequestDto updateRequest);
        Task<Response<int>> ActivateAsync(int siteId, ActivateRequestDto updateRequest);
        Task<Response<int>> ChangeThemeAsync(int siteId, ChangeThemeRequestDto updateRequest);
    }
}