using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.Asset;
using QuickCode.DemoCms.AssetManagementModule.Application.Services.Asset;
using QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.AssetManagementModule.Api.Controllers
{
    public partial class AssetsController : QuickCodeBaseApiController
    {
        private readonly IAssetService service;
        private readonly ILogger<AssetsController> logger;
        private readonly IServiceProvider serviceProvider;
        public AssetsController(IAssetService service, IServiceProvider serviceProvider, ILogger<AssetsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AssetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Asset", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Asset") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssetDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Asset", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AssetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(AssetDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Asset") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, AssetDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Asset", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Asset", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-folder/{assetFolderId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByFolderResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByFolderAsync(int assetFolderId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByFolderAsync(assetFolderId, page, size);
            if (HandleResponseError(response, logger, "Asset", $"AssetFolderId: '{assetFolderId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("search-by-filename/{assetFilename}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SearchByFilenameResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SearchByFilenameAsync(string assetFilename, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.SearchByFilenameAsync(assetFilename, page, size);
            if (HandleResponseError(response, logger, "Asset", $"AssetFilename: '{assetFilename}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-recently-uploaded")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetRecentlyUploadedResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecentlyUploadedAsync(int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetRecentlyUploadedAsync(page, size);
            if (HandleResponseError(response, logger, "Asset", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-kind/{assetKind}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByKindResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByKindAsync(AssetKind assetKind, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByKindAsync(assetKind, page, size);
            if (HandleResponseError(response, logger, "Asset", $"AssetKind: '{assetKind}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-assets-without-folder/{assetFolderId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAssetsWithoutFolderResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAssetsWithoutFolderAsync(int assetFolderId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetAssetsWithoutFolderAsync(assetFolderId, page, size);
            if (HandleResponseError(response, logger, "Asset", $"AssetFolderId: '{assetFolderId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}