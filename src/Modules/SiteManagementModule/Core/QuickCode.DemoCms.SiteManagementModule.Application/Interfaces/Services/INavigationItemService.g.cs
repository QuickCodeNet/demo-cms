using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.SiteManagementModule.Domain.Entities;
using QuickCode.DemoCms.SiteManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.NavigationItem;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Application.Services.NavigationItem
{
    public partial interface INavigationItemService
    {
        Task<Response<NavigationItemDto>> InsertAsync(NavigationItemDto request);
        Task<Response<bool>> DeleteAsync(NavigationItemDto request);
        Task<Response<bool>> UpdateAsync(int id, NavigationItemDto request);
        Task<Response<List<NavigationItemDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<NavigationItemDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByMenuIdResponseDto>>> GetByMenuIdAsync(int navigationItemMenuId, int? page, int? size);
        Task<Response<List<GetRootItemsResponseDto>>> GetRootItemsAsync(int navigationItemMenuId, int navigationItemParentItemId, int? page, int? size);
        Task<Response<List<GetChildItemsResponseDto>>> GetChildItemsAsync(int navigationItemParentItemId, int? page, int? size);
        Task<Response<int>> UpdateSortOrderAsync(int navigationItemId, UpdateSortOrderRequestDto updateRequest);
    }
}