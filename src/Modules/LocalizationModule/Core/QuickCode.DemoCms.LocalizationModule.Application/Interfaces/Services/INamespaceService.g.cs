using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.LocalizationModule.Domain.Entities;
using QuickCode.DemoCms.LocalizationModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.Namespace;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Application.Services.Namespace
{
    public partial interface INamespaceService
    {
        Task<Response<NamespaceDto>> InsertAsync(NamespaceDto request);
        Task<Response<bool>> DeleteAsync(NamespaceDto request);
        Task<Response<bool>> UpdateAsync(int id, NamespaceDto request);
        Task<Response<List<NamespaceDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<NamespaceDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool namespaceIsActive, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string namespaceName, int? page, int? size);
    }
}