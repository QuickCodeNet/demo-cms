using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.TranslationKey;
using QuickCode.DemoCms.LocalizationModule.Application.Services.TranslationKey;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Api.Controllers
{
    public partial class TranslationKeysController : QuickCodeBaseApiController
    {
        private readonly ITranslationKeyService service;
        private readonly ILogger<TranslationKeysController> logger;
        private readonly IServiceProvider serviceProvider;
        public TranslationKeysController(ITranslationKeyService service, IServiceProvider serviceProvider, ILogger<TranslationKeysController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TranslationKeyDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "TranslationKey", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "TranslationKey") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TranslationKeyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "TranslationKey", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TranslationKeyDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(TranslationKeyDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "TranslationKey") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, TranslationKeyDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "TranslationKey", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "TranslationKey", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-namespace/{translationKeyNamespaceId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByNamespaceResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByNamespaceAsync(int translationKeyNamespaceId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByNamespaceAsync(translationKeyNamespaceId, page, size);
            if (HandleResponseError(response, logger, "TranslationKey", $"TranslationKeyNamespaceId: '{translationKeyNamespaceId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("search-by-key/{translationKeyKey}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SearchByKeyResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SearchByKeyAsync(string translationKeyKey, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.SearchByKeyAsync(translationKeyKey, page, size);
            if (HandleResponseError(response, logger, "TranslationKey", $"TranslationKeyKey: '{translationKeyKey}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-untranslated-keys-for-language/{translationKeyNamespaceId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetUntranslatedKeysForLanguageResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetUntranslatedKeysForLanguageAsync(int translationKeyNamespaceId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetUntranslatedKeysForLanguageAsync(translationKeyNamespaceId, page, size);
            if (HandleResponseError(response, logger, "TranslationKey", $"TranslationKeyNamespaceId: '{translationKeyNamespaceId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}