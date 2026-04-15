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
    public partial class SiteService : ISiteService
    {
        private readonly ILogger<SiteService> _logger;
        private readonly ISiteRepository _repository;
        public SiteService(ILogger<SiteService> logger, ISiteRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<SiteDto>> InsertAsync(SiteDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(SiteDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, SiteDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SiteDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<SiteDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool siteIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(siteIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string siteName, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(siteName, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int siteId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(siteId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ActivateAsync(int siteId, ActivateRequestDto updateRequest)
        {
            var returnValue = await _repository.ActivateAsync(siteId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ChangeThemeAsync(int siteId, ChangeThemeRequestDto updateRequest)
        {
            var returnValue = await _repository.ChangeThemeAsync(siteId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}