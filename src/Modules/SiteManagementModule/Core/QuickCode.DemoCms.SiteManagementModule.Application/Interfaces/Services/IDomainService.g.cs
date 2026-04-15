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
    public partial interface IDomainService
    {
        Task<Response<DomainDto>> InsertAsync(DomainDto request);
        Task<Response<bool>> DeleteAsync(DomainDto request);
        Task<Response<bool>> UpdateAsync(int id, DomainDto request);
        Task<Response<List<DomainDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<DomainDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetBySiteIdResponseDto>>> GetBySiteIdAsync(int domainSiteId, int? page, int? size);
        Task<Response<GetSiteByHostnameResponseDto>> GetSiteByHostnameAsync(string domainHostname, bool domainIsActive);
        Task<Response<int>> SetAsPrimaryAsync(int domainId, int domainSiteId, SetAsPrimaryRequestDto updateRequest);
        Task<Response<int>> DeactivateAsync(int domainId, DeactivateRequestDto updateRequest);
    }
}