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
    public partial class BlockTranslationService : IBlockTranslationService
    {
        private readonly ILogger<BlockTranslationService> _logger;
        private readonly IBlockTranslationRepository _repository;
        public BlockTranslationService(ILogger<BlockTranslationService> logger, IBlockTranslationRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<BlockTranslationDto>> InsertAsync(BlockTranslationDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(BlockTranslationDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, BlockTranslationDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<BlockTranslationDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<BlockTranslationDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByBlockIdResponseDto>>> GetByBlockIdAsync(int blockTranslationBlockId, int? page, int? size)
        {
            var returnValue = await _repository.GetByBlockIdAsync(blockTranslationBlockId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByBlockAndLanguageResponseDto>> GetByBlockAndLanguageAsync(int blockTranslationBlockId, string blockTranslationLanguageCode)
        {
            var returnValue = await _repository.GetByBlockAndLanguageAsync(blockTranslationBlockId, blockTranslationLanguageCode);
            return returnValue.ToResponse();
        }
    }
}