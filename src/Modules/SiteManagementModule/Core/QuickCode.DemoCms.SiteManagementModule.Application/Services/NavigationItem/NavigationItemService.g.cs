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
    public partial class NavigationItemService : INavigationItemService
    {
        private readonly ILogger<NavigationItemService> _logger;
        private readonly INavigationItemRepository _repository;
        public NavigationItemService(ILogger<NavigationItemService> logger, INavigationItemRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<NavigationItemDto>> InsertAsync(NavigationItemDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(NavigationItemDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, NavigationItemDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<NavigationItemDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<NavigationItemDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByMenuIdResponseDto>>> GetByMenuIdAsync(int navigationItemMenuId, int? page, int? size)
        {
            var returnValue = await _repository.GetByMenuIdAsync(navigationItemMenuId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRootItemsResponseDto>>> GetRootItemsAsync(int navigationItemMenuId, int navigationItemParentItemId, int? page, int? size)
        {
            var returnValue = await _repository.GetRootItemsAsync(navigationItemMenuId, navigationItemParentItemId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetChildItemsResponseDto>>> GetChildItemsAsync(int navigationItemParentItemId, int? page, int? size)
        {
            var returnValue = await _repository.GetChildItemsAsync(navigationItemParentItemId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateSortOrderAsync(int navigationItemId, UpdateSortOrderRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateSortOrderAsync(navigationItemId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}