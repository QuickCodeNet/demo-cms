using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.Page;
using QuickCode.DemoCms.ContentManagementModule.Application.Services.Page;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Api.Controllers
{
    public partial class PagesController : QuickCodeBaseApiController
    {
        private readonly IPageService service;
        private readonly ILogger<PagesController> logger;
        private readonly IServiceProvider serviceProvider;
        public PagesController(IPageService service, IServiceProvider serviceProvider, ILogger<PagesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PageDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Page", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Page") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PageDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Page", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PageDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(PageDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Page") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, PageDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Page", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Page", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-published/{pageStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetPublishedResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetPublishedAsync(ContentStatus pageStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetPublishedAsync(pageStatus, page, size);
            if (HandleResponseError(response, logger, "Page", $"PageStatus: '{pageStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-drafts/{pageStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetDraftsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetDraftsAsync(ContentStatus pageStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetDraftsAsync(pageStatus, page, size);
            if (HandleResponseError(response, logger, "Page", $"PageStatus: '{pageStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-pending-review/{pageStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetPendingReviewResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetPendingReviewAsync(ContentStatus pageStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetPendingReviewAsync(pageStatus, page, size);
            if (HandleResponseError(response, logger, "Page", $"PageStatus: '{pageStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-child-pages/{pageParentPageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetChildPagesResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetChildPagesAsync(int pageParentPageId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetChildPagesAsync(pageParentPageId, page, size);
            if (HandleResponseError(response, logger, "Page", $"PageParentPageId: '{pageParentPageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("publish/{pageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> PublishAsync(int pageId, [FromBody] PublishRequestDto updateRequest)
        {
            var response = await service.PublishAsync(pageId, updateRequest);
            if (HandleResponseError(response, logger, "Page", $"PageId: '{pageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("archive/{pageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ArchiveAsync(int pageId, [FromBody] ArchiveRequestDto updateRequest)
        {
            var response = await service.ArchiveAsync(pageId, updateRequest);
            if (HandleResponseError(response, logger, "Page", $"PageId: '{pageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("revert-to-draft/{pageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> RevertToDraftAsync(int pageId, [FromBody] RevertToDraftRequestDto updateRequest)
        {
            var response = await service.RevertToDraftAsync(pageId, updateRequest);
            if (HandleResponseError(response, logger, "Page", $"PageId: '{pageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("request-review/{pageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> RequestReviewAsync(int pageId, [FromBody] RequestReviewRequestDto updateRequest)
        {
            var response = await service.RequestReviewAsync(pageId, updateRequest);
            if (HandleResponseError(response, logger, "Page", $"PageId: '{pageId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}