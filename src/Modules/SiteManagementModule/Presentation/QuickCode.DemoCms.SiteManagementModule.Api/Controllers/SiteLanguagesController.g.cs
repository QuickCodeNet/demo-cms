using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.SiteLanguage;
using QuickCode.DemoCms.SiteManagementModule.Application.Services.SiteLanguage;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Api.Controllers
{
    public partial class SiteLanguagesController : QuickCodeBaseApiController
    {
        private readonly ISiteLanguageService service;
        private readonly ILogger<SiteLanguagesController> logger;
        private readonly IServiceProvider serviceProvider;
        public SiteLanguagesController(ISiteLanguageService service, IServiceProvider serviceProvider, ILogger<SiteLanguagesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SiteLanguageDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "SiteLanguage", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "SiteLanguage") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{siteId:int}/{languageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SiteLanguageDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int siteId, int languageId)
        {
            var response = await service.GetItemAsync(siteId, languageId);
            if (HandleResponseError(response, logger, "SiteLanguage", $"SiteId: '{siteId}', LanguageId: '{languageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SiteLanguageDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(SiteLanguageDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "SiteLanguage") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { siteId = response.Value.SiteId, languageId = response.Value.LanguageId }, response.Value);
        }

        [HttpPut("{siteId:int}/{languageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int siteId, int languageId, SiteLanguageDto model)
        {
            if (!(model.SiteId == siteId && model.LanguageId == languageId))
            {
                return BadRequest($"SiteId: '{siteId}', LanguageId: '{languageId}' must be equal to model.SiteId: '{model.SiteId}', model.LanguageId: '{model.LanguageId}'");
            }

            var response = await service.UpdateAsync(siteId, languageId, model);
            if (HandleResponseError(response, logger, "SiteLanguage", $"SiteId: '{siteId}', LanguageId: '{languageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("{siteId:int}/{languageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteAsync(int siteId, int languageId)
        {
            var response = await service.DeleteItemAsync(siteId, languageId);
            if (HandleResponseError(response, logger, "SiteLanguage", $"SiteId: '{siteId}', LanguageId: '{languageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-languages-for-site/{siteLanguageSiteId:int}/{siteLanguageIsEnabled:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetLanguagesForSiteResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetLanguagesForSiteAsync(int siteLanguageSiteId, bool siteLanguageIsEnabled)
        {
            var response = await service.GetLanguagesForSiteAsync(siteLanguageSiteId, siteLanguageIsEnabled);
            if (HandleResponseError(response, logger, "SiteLanguage", $"SiteLanguageSiteId: '{siteLanguageSiteId}', SiteLanguageIsEnabled: '{siteLanguageIsEnabled}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("enable-language/{siteLanguageSiteId:int}/{siteLanguageLanguageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> EnableLanguageAsync(int siteLanguageSiteId, int siteLanguageLanguageId, [FromBody] EnableLanguageRequestDto updateRequest)
        {
            var response = await service.EnableLanguageAsync(siteLanguageSiteId, siteLanguageLanguageId, updateRequest);
            if (HandleResponseError(response, logger, "SiteLanguage", $"SiteLanguageSiteId: '{siteLanguageSiteId}', SiteLanguageLanguageId: '{siteLanguageLanguageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("disable-language/{siteLanguageSiteId:int}/{siteLanguageLanguageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DisableLanguageAsync(int siteLanguageSiteId, int siteLanguageLanguageId, [FromBody] DisableLanguageRequestDto updateRequest)
        {
            var response = await service.DisableLanguageAsync(siteLanguageSiteId, siteLanguageLanguageId, updateRequest);
            if (HandleResponseError(response, logger, "SiteLanguage", $"SiteLanguageSiteId: '{siteLanguageSiteId}', SiteLanguageLanguageId: '{siteLanguageLanguageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}