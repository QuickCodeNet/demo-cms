using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.Tag;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.Tag
{
    public partial interface ITagService
    {
        Task<Response<TagDto>> InsertAsync(TagDto request);
        Task<Response<bool>> DeleteAsync(TagDto request);
        Task<Response<bool>> UpdateAsync(int id, TagDto request);
        Task<Response<List<TagDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TagDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string tagName, int? page, int? size);
        Task<Response<GetBySlugResponseDto>> GetBySlugAsync(string tagSlug);
    }
}