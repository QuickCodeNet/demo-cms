using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.AssetMetadata;
using QuickCode.DemoCms.AssetManagementModule.Application.Services.AssetMetadata;
using QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.AssetManagementModule.Api.Controllers
{
    public partial class AssetMetadataController : QuickCodeBaseApiController
    {
        private readonly IAssetMetadataService service;
        private readonly ILogger<AssetMetadataController> logger;
        private readonly IServiceProvider serviceProvider;
        public AssetMetadataController(IAssetMetadataService service, IServiceProvider serviceProvider, ILogger<AssetMetadataController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AssetMetadataDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "AssetMetadata", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "AssetMetadata") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AssetMetadataDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "AssetMetadata", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AssetMetadataDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(AssetMetadataDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "AssetMetadata") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, AssetMetadataDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "AssetMetadata", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "AssetMetadata", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-metadata-for-asset/{assetMetadataAssetId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetMetadataForAssetResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetMetadataForAssetAsync(int assetMetadataAssetId)
        {
            var response = await service.GetMetadataForAssetAsync(assetMetadataAssetId);
            if (HandleResponseError(response, logger, "AssetMetadata", $"AssetMetadataAssetId: '{assetMetadataAssetId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-assets-by-metadata/{assetMetadataKey}/{assetMetadataValue}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAssetsByMetadataResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAssetsByMetadataAsync(string assetMetadataKey, string assetMetadataValue, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetAssetsByMetadataAsync(assetMetadataKey, assetMetadataValue, page, size);
            if (HandleResponseError(response, logger, "AssetMetadata", $"AssetMetadataKey: '{assetMetadataKey}', AssetMetadataValue: '{assetMetadataValue}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-metadata-value/{assetMetadataAssetId:int}/{assetMetadataKey}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateMetadataValueAsync(int assetMetadataAssetId, string assetMetadataKey, [FromBody] UpdateMetadataValueRequestDto updateRequest)
        {
            var response = await service.UpdateMetadataValueAsync(assetMetadataAssetId, assetMetadataKey, updateRequest);
            if (HandleResponseError(response, logger, "AssetMetadata", $"AssetMetadataAssetId: '{assetMetadataAssetId}', AssetMetadataKey: '{assetMetadataKey}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}