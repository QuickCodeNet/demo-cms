using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.PageTranslation;
using QuickCode.DemoCms.ContentManagementModule.Application.Services.PageTranslation;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Api.Controllers
{
    public partial class PageTranslationsController : QuickCodeBaseApiController
    {
        private readonly IPageTranslationService service;
        private readonly ILogger<PageTranslationsController> logger;
        private readonly IServiceProvider serviceProvider;
        public PageTranslationsController(IPageTranslationService service, IServiceProvider serviceProvider, ILogger<PageTranslationsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PageTranslationDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "PageTranslation", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "PageTranslation") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PageTranslationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "PageTranslation", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PageTranslationDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(PageTranslationDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "PageTranslation") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, PageTranslationDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "PageTranslation", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "PageTranslation", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-page-id/{pageTranslationPageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByPageIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByPageIdAsync(int pageTranslationPageId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByPageIdAsync(pageTranslationPageId, page, size);
            if (HandleResponseError(response, logger, "PageTranslation", $"PageTranslationPageId: '{pageTranslationPageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-page-and-language/{pageTranslationPageId:int}/{pageTranslationLanguageCode}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetByPageAndLanguageResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByPageAndLanguageAsync(int pageTranslationPageId, string pageTranslationLanguageCode)
        {
            var response = await service.GetByPageAndLanguageAsync(pageTranslationPageId, pageTranslationLanguageCode);
            if (HandleResponseError(response, logger, "PageTranslation", $"PageTranslationPageId: '{pageTranslationPageId}', PageTranslationLanguageCode: '{pageTranslationLanguageCode}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-slug-and-language/{pageTranslationLanguageCode}/{pageTranslationSlug}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBySlugAndLanguageResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetBySlugAndLanguageAsync(string pageTranslationLanguageCode, string pageTranslationSlug)
        {
            var response = await service.GetBySlugAndLanguageAsync(pageTranslationLanguageCode, pageTranslationSlug);
            if (HandleResponseError(response, logger, "PageTranslation", $"PageTranslationLanguageCode: '{pageTranslationLanguageCode}', PageTranslationSlug: '{pageTranslationSlug}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("check-slug-exists/{pageTranslationLanguageCode}/{pageTranslationSlug}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CheckSlugExistsAsync(string pageTranslationLanguageCode, string pageTranslationSlug)
        {
            var response = await service.CheckSlugExistsAsync(pageTranslationLanguageCode, pageTranslationSlug);
            if (HandleResponseError(response, logger, "PageTranslation", $"PageTranslationLanguageCode: '{pageTranslationLanguageCode}', PageTranslationSlug: '{pageTranslationSlug}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}