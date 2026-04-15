using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.SiteSetting;
using QuickCode.DemoCms.SiteManagementModule.Application.Services.SiteSetting;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Api.Controllers
{
    public partial class SiteSettingsController : QuickCodeBaseApiController
    {
        private readonly ISiteSettingService service;
        private readonly ILogger<SiteSettingsController> logger;
        private readonly IServiceProvider serviceProvider;
        public SiteSettingsController(ISiteSettingService service, IServiceProvider serviceProvider, ILogger<SiteSettingsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SiteSettingDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "SiteSetting", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "SiteSetting") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SiteSettingDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "SiteSetting", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SiteSettingDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(SiteSettingDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "SiteSetting") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, SiteSettingDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "SiteSetting", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await service.DeleteItemAsync(id);
            if (HandleResponseError(response, logger, "SiteSetting", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-settings-for-site/{siteSettingSiteId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetSettingsForSiteResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSettingsForSiteAsync(int siteSettingSiteId)
        {
            var response = await service.GetSettingsForSiteAsync(siteSettingSiteId);
            if (HandleResponseError(response, logger, "SiteSetting", $"SiteSettingSiteId: '{siteSettingSiteId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-setting-by-key/{siteSettingSiteId:int}/{siteSettingKey}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetSettingByKeyResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSettingByKeyAsync(int siteSettingSiteId, string siteSettingKey)
        {
            var response = await service.GetSettingByKeyAsync(siteSettingSiteId, siteSettingKey);
            if (HandleResponseError(response, logger, "SiteSetting", $"SiteSettingSiteId: '{siteSettingSiteId}', SiteSettingKey: '{siteSettingKey}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-value/{siteSettingSiteId:int}/{siteSettingKey}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateValueAsync(int siteSettingSiteId, string siteSettingKey, [FromBody] UpdateValueRequestDto updateRequest)
        {
            var response = await service.UpdateValueAsync(siteSettingSiteId, siteSettingKey, updateRequest);
            if (HandleResponseError(response, logger, "SiteSetting", $"SiteSettingSiteId: '{siteSettingSiteId}', SiteSettingKey: '{siteSettingKey}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}