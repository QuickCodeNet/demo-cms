using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.SiteManagementModule.Domain.Entities;
using QuickCode.DemoCms.SiteManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.NavigationMenu;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Application.Services.NavigationMenu
{
    public partial interface INavigationMenuService
    {
        Task<Response<NavigationMenuDto>> InsertAsync(NavigationMenuDto request);
        Task<Response<bool>> DeleteAsync(NavigationMenuDto request);
        Task<Response<bool>> UpdateAsync(int id, NavigationMenuDto request);
        Task<Response<List<NavigationMenuDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<NavigationMenuDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetBySiteIdResponseDto>>> GetBySiteIdAsync(int navigationMenuSiteId, int? page, int? size);
        Task<Response<GetByLocationResponseDto>> GetByLocationAsync(int navigationMenuSiteId, string navigationMenuLocationKey);
    }
}