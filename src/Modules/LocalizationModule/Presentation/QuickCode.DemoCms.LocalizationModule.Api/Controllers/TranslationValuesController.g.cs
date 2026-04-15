using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.TranslationValue;
using QuickCode.DemoCms.LocalizationModule.Application.Services.TranslationValue;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Api.Controllers
{
    public partial class TranslationValuesController : QuickCodeBaseApiController
    {
        private readonly ITranslationValueService service;
        private readonly ILogger<TranslationValuesController> logger;
        private readonly IServiceProvider serviceProvider;
        public TranslationValuesController(ITranslationValueService service, IServiceProvider serviceProvider, ILogger<TranslationValuesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TranslationValueDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "TranslationValue", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "TranslationValue") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TranslationValueDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "TranslationValue", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TranslationValueDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(TranslationValueDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "TranslationValue") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, TranslationValueDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "TranslationValue", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "TranslationValue", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-key-and-language/{translationValueKeyId:int}/{translationValueLanguageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetByKeyAndLanguageResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByKeyAndLanguageAsync(int translationValueKeyId, int translationValueLanguageId)
        {
            var response = await service.GetByKeyAndLanguageAsync(translationValueKeyId, translationValueLanguageId);
            if (HandleResponseError(response, logger, "TranslationValue", $"TranslationValueKeyId: '{translationValueKeyId}', TranslationValueLanguageId: '{translationValueLanguageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-translations-for-language-and-namespace/{translationValuesLanguageId:int}/{translationKeysNamespaceId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetTranslationsForLanguageAndNamespaceResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTranslationsForLanguageAndNamespaceAsync(int translationValuesLanguageId, int translationKeysNamespaceId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetTranslationsForLanguageAndNamespaceAsync(translationValuesLanguageId, translationKeysNamespaceId, page, size);
            if (HandleResponseError(response, logger, "TranslationValue", $"TranslationValuesLanguageId: '{translationValuesLanguageId}', TranslationKeysNamespaceId: '{translationKeysNamespaceId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("bulk-upsert/{translationValueKeyId:int}/{translationValueLanguageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> BulkUpsertAsync(int translationValueKeyId, int translationValueLanguageId, [FromBody] BulkUpsertRequestDto updateRequest)
        {
            var response = await service.BulkUpsertAsync(translationValueKeyId, translationValueLanguageId, updateRequest);
            if (HandleResponseError(response, logger, "TranslationValue", $"TranslationValueKeyId: '{translationValueKeyId}', TranslationValueLanguageId: '{translationValueLanguageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}