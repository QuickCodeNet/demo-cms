using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.LanguageFallback;
using QuickCode.DemoCms.LocalizationModule.Application.Services.LanguageFallback;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Api.Controllers
{
    public partial class LanguageFallbacksController : QuickCodeBaseApiController
    {
        private readonly ILanguageFallbackService service;
        private readonly ILogger<LanguageFallbacksController> logger;
        private readonly IServiceProvider serviceProvider;
        public LanguageFallbacksController(ILanguageFallbackService service, IServiceProvider serviceProvider, ILogger<LanguageFallbacksController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LanguageFallbackDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "LanguageFallback", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "LanguageFallback") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{languageId:int}/{fallbackLanguageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LanguageFallbackDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int languageId, int fallbackLanguageId)
        {
            var response = await service.GetItemAsync(languageId, fallbackLanguageId);
            if (HandleResponseError(response, logger, "LanguageFallback", $"LanguageId: '{languageId}', FallbackLanguageId: '{fallbackLanguageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LanguageFallbackDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(LanguageFallbackDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "LanguageFallback") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { languageId = response.Value.LanguageId, fallbackLanguageId = response.Value.FallbackLanguageId }, response.Value);
        }

        [HttpPut("{languageId:int}/{fallbackLanguageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int languageId, int fallbackLanguageId, LanguageFallbackDto model)
        {
            if (!(model.LanguageId == languageId && model.FallbackLanguageId == fallbackLanguageId))
            {
                return BadRequest($"LanguageId: '{languageId}', FallbackLanguageId: '{fallbackLanguageId}' must be equal to model.LanguageId: '{model.LanguageId}', model.FallbackLanguageId: '{model.FallbackLanguageId}'");
            }

            var response = await service.UpdateAsync(languageId, fallbackLanguageId, model);
            if (HandleResponseError(response, logger, "LanguageFallback", $"LanguageId: '{languageId}', FallbackLanguageId: '{fallbackLanguageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("{languageId:int}/{fallbackLanguageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteAsync(int languageId, int fallbackLanguageId)
        {
            var response = await service.DeleteItemAsync(languageId, fallbackLanguageId);
            if (HandleResponseError(response, logger, "LanguageFallback", $"LanguageId: '{languageId}', FallbackLanguageId: '{fallbackLanguageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-fallbacks-for-language/{languageFallbackLanguageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetFallbacksForLanguageResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetFallbacksForLanguageAsync(int languageFallbackLanguageId)
        {
            var response = await service.GetFallbacksForLanguageAsync(languageFallbackLanguageId);
            if (HandleResponseError(response, logger, "LanguageFallback", $"LanguageFallbackLanguageId: '{languageFallbackLanguageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("remove-fallback/{languageFallbackLanguageId:int}/{languageFallbackFallbackLanguageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> RemoveFallbackAsync(int languageFallbackLanguageId, int languageFallbackFallbackLanguageId)
        {
            var response = await service.RemoveFallbackAsync(languageFallbackLanguageId, languageFallbackFallbackLanguageId);
            if (HandleResponseError(response, logger, "LanguageFallback", $"LanguageFallbackLanguageId: '{languageFallbackLanguageId}', LanguageFallbackFallbackLanguageId: '{languageFallbackFallbackLanguageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}