using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.SiteManagementModule.Domain.Entities;
using QuickCode.DemoCms.SiteManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.Theme;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Application.Services.Theme
{
    public partial interface IThemeService
    {
        Task<Response<ThemeDto>> InsertAsync(ThemeDto request);
        Task<Response<bool>> DeleteAsync(ThemeDto request);
        Task<Response<bool>> UpdateAsync(int id, ThemeDto request);
        Task<Response<List<ThemeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ThemeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool themeIsActive, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string themeName, int? page, int? size);
        Task<Response<int>> DeactivateAsync(int themeId, DeactivateRequestDto updateRequest);
    }
}