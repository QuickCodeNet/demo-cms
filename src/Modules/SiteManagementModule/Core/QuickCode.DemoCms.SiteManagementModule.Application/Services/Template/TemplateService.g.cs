using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.SiteManagementModule.Domain.Entities;
using QuickCode.DemoCms.SiteManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.Template;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Application.Services.Template
{
    public partial class TemplateService : ITemplateService
    {
        private readonly ILogger<TemplateService> _logger;
        private readonly ITemplateRepository _repository;
        public TemplateService(ILogger<TemplateService> logger, ITemplateRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<TemplateDto>> InsertAsync(TemplateDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(TemplateDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, TemplateDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<TemplateDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<TemplateDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByThemeIdResponseDto>>> GetByThemeIdAsync(int templateThemeId, int? page, int? size)
        {
            var returnValue = await _repository.GetByThemeIdAsync(templateThemeId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByKeyResponseDto>> GetByKeyAsync(int templateThemeId, string templateKey)
        {
            var returnValue = await _repository.GetByKeyAsync(templateThemeId, templateKey);
            return returnValue.ToResponse();
        }
    }
}