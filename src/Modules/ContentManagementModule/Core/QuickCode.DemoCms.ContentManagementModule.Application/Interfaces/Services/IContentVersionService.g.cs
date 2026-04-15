using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.ContentVersion;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.ContentVersion
{
    public partial interface IContentVersionService
    {
        Task<Response<ContentVersionDto>> InsertAsync(ContentVersionDto request);
        Task<Response<bool>> DeleteAsync(ContentVersionDto request);
        Task<Response<bool>> UpdateAsync(int id, ContentVersionDto request);
        Task<Response<List<ContentVersionDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ContentVersionDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetVersionsForContentResponseDto>>> GetVersionsForContentAsync(ContentKind contentVersionContentTypeKind, int contentVersionContentId, int contentVersionTranslationId, int? page, int? size);
        Task<Response<GetSpecificVersionResponseDto>> GetSpecificVersionAsync(int contentVersionId);
    }
}