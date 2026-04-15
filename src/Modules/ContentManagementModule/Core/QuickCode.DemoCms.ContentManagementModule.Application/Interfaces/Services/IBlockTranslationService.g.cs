using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.BlockTranslation;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Services.BlockTranslation
{
    public partial interface IBlockTranslationService
    {
        Task<Response<BlockTranslationDto>> InsertAsync(BlockTranslationDto request);
        Task<Response<bool>> DeleteAsync(BlockTranslationDto request);
        Task<Response<bool>> UpdateAsync(int id, BlockTranslationDto request);
        Task<Response<List<BlockTranslationDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<BlockTranslationDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByBlockIdResponseDto>>> GetByBlockIdAsync(int blockTranslationBlockId, int? page, int? size);
        Task<Response<GetByBlockAndLanguageResponseDto>> GetByBlockAndLanguageAsync(int blockTranslationBlockId, string blockTranslationLanguageCode);
    }
}