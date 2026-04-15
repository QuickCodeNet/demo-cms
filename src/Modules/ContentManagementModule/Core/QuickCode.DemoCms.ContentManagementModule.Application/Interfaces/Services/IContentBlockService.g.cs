using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.ContentBlock;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.ContentBlock
{
    public partial interface IContentBlockService
    {
        Task<Response<ContentBlockDto>> InsertAsync(ContentBlockDto request);
        Task<Response<bool>> DeleteAsync(ContentBlockDto request);
        Task<Response<bool>> UpdateAsync(int id, ContentBlockDto request);
        Task<Response<List<ContentBlockDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ContentBlockDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool contentBlockIsActive, int? page, int? size);
        Task<Response<GetByKeyResponseDto>> GetByKeyAsync(string contentBlockKey, bool contentBlockIsActive);
        Task<Response<List<SearchByKeyResponseDto>>> SearchByKeyAsync(string contentBlockKey, bool contentBlockIsActive, int? page, int? size);
        Task<Response<int>> DeactivateAsync(int contentBlockId, DeactivateRequestDto updateRequest);
    }
}