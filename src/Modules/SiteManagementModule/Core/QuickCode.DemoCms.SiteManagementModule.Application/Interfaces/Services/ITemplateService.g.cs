using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.SiteManagementModule.Domain.Entities;
using QuickCode.DemoCms.SiteManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.Template;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Application.Services.Template
{
    public partial interface ITemplateService
    {
        Task<Response<TemplateDto>> InsertAsync(TemplateDto request);
        Task<Response<bool>> DeleteAsync(TemplateDto request);
        Task<Response<bool>> UpdateAsync(int id, TemplateDto request);
        Task<Response<List<TemplateDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TemplateDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByThemeIdResponseDto>>> GetByThemeIdAsync(int templateThemeId, int? page, int? size);
        Task<Response<GetByKeyResponseDto>> GetByKeyAsync(int templateThemeId, string templateKey);
    }
}