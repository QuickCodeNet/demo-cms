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
    public partial class NavigationMenuService : INavigationMenuService
    {
        private readonly ILogger<NavigationMenuService> _logger;
        private readonly INavigationMenuRepository _repository;
        public NavigationMenuService(ILogger<NavigationMenuService> logger, INavigationMenuRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<NavigationMenuDto>> InsertAsync(NavigationMenuDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(NavigationMenuDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, NavigationMenuDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<NavigationMenuDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<NavigationMenuDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetBySiteIdResponseDto>>> GetBySiteIdAsync(int navigationMenuSiteId, int? page, int? size)
        {
            var returnValue = await _repository.GetBySiteIdAsync(navigationMenuSiteId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByLocationResponseDto>> GetByLocationAsync(int navigationMenuSiteId, string navigationMenuLocationKey)
        {
            var returnValue = await _repository.GetByLocationAsync(navigationMenuSiteId, navigationMenuLocationKey);
            return returnValue.ToResponse();
        }
    }
}