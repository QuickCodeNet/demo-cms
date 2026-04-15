using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.Common.Controllers;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.Domain;
using QuickCode.DemoCms.SiteManagementModule.Application.Services.Domain;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Api.Controllers
{
    public partial class DomainsController : QuickCodeBaseApiController
    {
        private readonly IDomainService service;
        private readonly ILogger<DomainsController> logger;
        private readonly IServiceProvider serviceProvider;
        public DomainsController(IDomainService service, IServiceProvider serviceProvider, ILogger<DomainsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DomainDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Domain", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Domain") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DomainDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Domain", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DomainDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(DomainDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Domain") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, DomainDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Domain", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Domain", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-site-id/{domainSiteId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetBySiteIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetBySiteIdAsync(int domainSiteId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetBySiteIdAsync(domainSiteId, page, size);
            if (HandleResponseError(response, logger, "Domain", $"DomainSiteId: '{domainSiteId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-site-by-hostname/{domainHostname}/{domainIsActive:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetSiteByHostnameResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSiteByHostnameAsync(string domainHostname, bool domainIsActive)
        {
            var response = await service.GetSiteByHostnameAsync(domainHostname, domainIsActive);
            if (HandleResponseError(response, logger, "Domain", $"DomainHostname: '{domainHostname}', DomainIsActive: '{domainIsActive}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("set-as-primary/{domainId:int}/{domainSiteId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SetAsPrimaryAsync(int domainId, int domainSiteId, [FromBody] SetAsPrimaryRequestDto updateRequest)
        {
            var response = await service.SetAsPrimaryAsync(domainId, domainSiteId, updateRequest);
            if (HandleResponseError(response, logger, "Domain", $"DomainId: '{domainId}', DomainSiteId: '{domainSiteId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("deactivate/{domainId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeactivateAsync(int domainId, [FromBody] DeactivateRequestDto updateRequest)
        {
            var response = await service.DeactivateAsync(domainId, updateRequest);
            if (HandleResponseError(response, logger, "Domain", $"DomainId: '{domainId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}