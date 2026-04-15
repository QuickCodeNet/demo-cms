using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.ContentType;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.ContentType
{
    public partial interface IContentTypeService
    {
        Task<Response<ContentTypeDto>> InsertAsync(ContentTypeDto request);
        Task<Response<bool>> DeleteAsync(ContentTypeDto request);
        Task<Response<bool>> UpdateAsync(int id, ContentTypeDto request);
        Task<Response<List<ContentTypeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ContentTypeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool contentTypeIsActive, int? page, int? size);
        Task<Response<List<GetByKindResponseDto>>> GetByKindAsync(ContentKind contentTypeKind, bool contentTypeIsActive, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string contentTypeName, bool contentTypeIsActive, int? page, int? size);
        Task<Response<GetByApiKeyResponseDto>> GetByApiKeyAsync(string contentTypeApiKey);
        Task<Response<int>> DeactivateAsync(int contentTypeId, DeactivateRequestDto updateRequest);
    }
}