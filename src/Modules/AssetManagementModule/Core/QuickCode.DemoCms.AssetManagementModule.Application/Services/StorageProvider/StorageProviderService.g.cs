using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.AssetManagementModule.Domain.Entities;
using QuickCode.DemoCms.AssetManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.StorageProvider;
using QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.AssetManagementModule.Application.Services.StorageProvider
{
    public partial class StorageProviderService : IStorageProviderService
    {
        private readonly ILogger<StorageProviderService> _logger;
        private readonly IStorageProviderRepository _repository;
        public StorageProviderService(ILogger<StorageProviderService> logger, IStorageProviderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<StorageProviderDto>> InsertAsync(StorageProviderDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(StorageProviderDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, StorageProviderDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<StorageProviderDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<StorageProviderDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool storageProviderIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(storageProviderIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetDefaultResponseDto>> GetDefaultAsync(bool storageProviderIsDefault, bool storageProviderIsActive)
        {
            var returnValue = await _repository.GetDefaultAsync(storageProviderIsDefault, storageProviderIsActive);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> SetAsDefaultAsync(int storageProviderId, SetAsDefaultRequestDto updateRequest)
        {
            var returnValue = await _repository.SetAsDefaultAsync(storageProviderId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int storageProviderId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(storageProviderId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}