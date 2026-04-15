using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.LocalizationModule.Domain.Entities;
using QuickCode.DemoCms.LocalizationModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.ResourceFile;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Application.Services.ResourceFile
{
    public partial class ResourceFileService : IResourceFileService
    {
        private readonly ILogger<ResourceFileService> _logger;
        private readonly IResourceFileRepository _repository;
        public ResourceFileService(ILogger<ResourceFileService> logger, IResourceFileRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ResourceFileDto>> InsertAsync(ResourceFileDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ResourceFileDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ResourceFileDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ResourceFileDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ResourceFileDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetPendingImportsResponseDto>>> GetPendingImportsAsync(string resourceFileStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetPendingImportsAsync(resourceFileStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetImportHistoryResponseDto>>> GetImportHistoryAsync(int resourceFileLanguageId, int? page, int? size)
        {
            var returnValue = await _repository.GetImportHistoryAsync(resourceFileLanguageId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> MarkAsProcessedAsync(int resourceFileId, MarkAsProcessedRequestDto updateRequest)
        {
            var returnValue = await _repository.MarkAsProcessedAsync(resourceFileId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> MarkAsFailedAsync(int resourceFileId, MarkAsFailedRequestDto updateRequest)
        {
            var returnValue = await _repository.MarkAsFailedAsync(resourceFileId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}