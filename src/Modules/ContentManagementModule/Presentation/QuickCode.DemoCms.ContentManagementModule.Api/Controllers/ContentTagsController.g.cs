using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.ContentTag;
using QuickCode.DemoCms.ContentManagementModule.Application.Services.ContentTag;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Api.Controllers
{
    public partial class ContentTagsController : QuickCodeBaseApiController
    {
        private readonly IContentTagService service;
        private readonly ILogger<ContentTagsController> logger;
        private readonly IServiceProvider serviceProvider;
        public ContentTagsController(IContentTagService service, IServiceProvider serviceProvider, ILogger<ContentTagsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ContentTagDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "ContentTag", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "ContentTag") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{contentTypeKind}/{contentId:int}/{tagId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContentTagDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(ContentKind contentTypeKind, int contentId, int tagId)
        {
            var response = await service.GetItemAsync(contentTypeKind, contentId, tagId);
            if (HandleResponseError(response, logger, "ContentTag", $"ContentTypeKind: '{contentTypeKind}', ContentId: '{contentId}', TagId: '{tagId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ContentTagDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(ContentTagDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "ContentTag") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { contentTypeKind = response.Value.ContentTypeKind, contentId = response.Value.ContentId, tagId = response.Value.TagId }, response.Value);
        }

        [HttpPut("{contentTypeKind}/{contentId:int}/{tagId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(ContentKind contentTypeKind, int contentId, int tagId, ContentTagDto model)
        {
            if (!(model.ContentTypeKind == contentTypeKind && model.ContentId == contentId && model.TagId == tagId))
            {
                return BadRequest($"ContentTypeKind: '{contentTypeKind}', ContentId: '{contentId}', TagId: '{tagId}' must be equal to model.ContentTypeKind: '{model.ContentTypeKind}', model.ContentId: '{model.ContentId}', model.TagId: '{model.TagId}'");
            }

            var response = await service.UpdateAsync(contentTypeKind, contentId, tagId, model);
            if (HandleResponseError(response, logger, "ContentTag", $"ContentTypeKind: '{contentTypeKind}', ContentId: '{contentId}', TagId: '{tagId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("{contentTypeKind}/{contentId:int}/{tagId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteAsync(ContentKind contentTypeKind, int contentId, int tagId)
        {
            var response = await service.DeleteItemAsync(contentTypeKind, contentId, tagId);
            if (HandleResponseError(response, logger, "ContentTag", $"ContentTypeKind: '{contentTypeKind}', ContentId: '{contentId}', TagId: '{tagId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-tags-for-content")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetTagsForContentResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTagsForContentAsync(ContentKind contentTagContentTypeKind, int contentTagContentId)
        {
            var response = await service.GetTagsForContentAsync(contentTagContentTypeKind, contentTagContentId);
            if (HandleResponseError(response, logger, "ContentTag", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-content-for-tag")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetContentForTagResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetContentForTagAsync(int contentTagTagId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetContentForTagAsync(contentTagTagId, page, size);
            if (HandleResponseError(response, logger, "ContentTag", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("remove-tag-from-content/{contentTagContentTypeKind}/{contentTagContentId:int}/{contentTagTagId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> RemoveTagFromContentAsync(ContentKind contentTagContentTypeKind, int contentTagContentId, int contentTagTagId)
        {
            var response = await service.RemoveTagFromContentAsync(contentTagContentTypeKind, contentTagContentId, contentTagTagId);
            if (HandleResponseError(response, logger, "ContentTag", $"ContentTagContentTypeKind: '{contentTagContentTypeKind}', ContentTagContentId: '{contentTagContentId}', ContentTagTagId: '{contentTagTagId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("remove-all-tags-from-content/{contentTagContentTypeKind}/{contentTagContentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> RemoveAllTagsFromContentAsync(ContentKind contentTagContentTypeKind, int contentTagContentId)
        {
            var response = await service.RemoveAllTagsFromContentAsync(contentTagContentTypeKind, contentTagContentId);
            if (HandleResponseError(response, logger, "ContentTag", $"ContentTagContentTypeKind: '{contentTagContentTypeKind}', ContentTagContentId: '{contentTagContentId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}