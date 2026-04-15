using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.ContentVersion;
using QuickCode.DemoCms.ContentManagementModule.Application.Services.ContentVersion;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Api.Controllers
{
    public partial class ContentVersionsController : QuickCodeBaseApiController
    {
        private readonly IContentVersionService service;
        private readonly ILogger<ContentVersionsController> logger;
        private readonly IServiceProvider serviceProvider;
        public ContentVersionsController(IContentVersionService service, IServiceProvider serviceProvider, ILogger<ContentVersionsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ContentVersionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "ContentVersion", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "ContentVersion") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContentVersionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "ContentVersion", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ContentVersionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(ContentVersionDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "ContentVersion") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, ContentVersionDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "ContentVersion", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "ContentVersion", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-versions-for-content/{contentVersionContentTypeKind}/{contentVersionContentId:int}/{contentVersionTranslationId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetVersionsForContentResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetVersionsForContentAsync(ContentKind contentVersionContentTypeKind, int contentVersionContentId, int contentVersionTranslationId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetVersionsForContentAsync(contentVersionContentTypeKind, contentVersionContentId, contentVersionTranslationId, page, size);
            if (HandleResponseError(response, logger, "ContentVersion", $"ContentVersionContentTypeKind: '{contentVersionContentTypeKind}', ContentVersionContentId: '{contentVersionContentId}', ContentVersionTranslationId: '{contentVersionTranslationId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-specific-version/{contentVersionId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetSpecificVersionResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSpecificVersionAsync(int contentVersionId)
        {
            var response = await service.GetSpecificVersionAsync(contentVersionId);
            if (HandleResponseError(response, logger, "ContentVersion", $"ContentVersionId: '{contentVersionId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}