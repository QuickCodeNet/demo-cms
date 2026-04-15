using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.SiteManagementModule.Domain.Entities;
using QuickCode.DemoCms.SiteManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.Domain;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Application.Services.Domain
{
    public partial class DomainService : IDomainService
    {
        private readonly ILogger<DomainService> _logger;
        private readonly IDomainRepository _repository;
        public DomainService(ILogger<DomainService> logger, IDomainRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<DomainDto>> InsertAsync(DomainDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(DomainDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, DomainDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<DomainDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<DomainDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetBySiteIdResponseDto>>> GetBySiteIdAsync(int domainSiteId, int? page, int? size)
        {
            var returnValue = await _repository.GetBySiteIdAsync(domainSiteId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetSiteByHostnameResponseDto>> GetSiteByHostnameAsync(string domainHostname, bool domainIsActive)
        {
            var returnValue = await _repository.GetSiteByHostnameAsync(domainHostname, domainIsActive);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> SetAsPrimaryAsync(int domainId, int domainSiteId, SetAsPrimaryRequestDto updateRequest)
        {
            var returnValue = await _repository.SetAsPrimaryAsync(domainId, domainSiteId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int domainId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(domainId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}