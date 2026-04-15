using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.NavigationItem;
using QuickCode.DemoCms.SiteManagementModule.Application.Services.NavigationItem;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Api.Controllers
{
    public partial class NavigationItemsController : QuickCodeBaseApiController
    {
        private readonly INavigationItemService service;
        private readonly ILogger<NavigationItemsController> logger;
        private readonly IServiceProvider serviceProvider;
        public NavigationItemsController(INavigationItemService service, IServiceProvider serviceProvider, ILogger<NavigationItemsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NavigationItemDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "NavigationItem", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "NavigationItem") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NavigationItemDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "NavigationItem", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NavigationItemDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(NavigationItemDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "NavigationItem") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, NavigationItemDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "NavigationItem", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "NavigationItem", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-menu-id/{navigationItemMenuId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByMenuIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByMenuIdAsync(int navigationItemMenuId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByMenuIdAsync(navigationItemMenuId, page, size);
            if (HandleResponseError(response, logger, "NavigationItem", $"NavigationItemMenuId: '{navigationItemMenuId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-root-items/{navigationItemMenuId:int}/{navigationItemParentItemId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetRootItemsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRootItemsAsync(int navigationItemMenuId, int navigationItemParentItemId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetRootItemsAsync(navigationItemMenuId, navigationItemParentItemId, page, size);
            if (HandleResponseError(response, logger, "NavigationItem", $"NavigationItemMenuId: '{navigationItemMenuId}', NavigationItemParentItemId: '{navigationItemParentItemId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-child-items/{navigationItemParentItemId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetChildItemsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetChildItemsAsync(int navigationItemParentItemId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetChildItemsAsync(navigationItemParentItemId, page, size);
            if (HandleResponseError(response, logger, "NavigationItem", $"NavigationItemParentItemId: '{navigationItemParentItemId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-sort-order/{navigationItemId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateSortOrderAsync(int navigationItemId, [FromBody] UpdateSortOrderRequestDto updateRequest)
        {
            var response = await service.UpdateSortOrderAsync(navigationItemId, updateRequest);
            if (HandleResponseError(response, logger, "NavigationItem", $"NavigationItemId: '{navigationItemId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}