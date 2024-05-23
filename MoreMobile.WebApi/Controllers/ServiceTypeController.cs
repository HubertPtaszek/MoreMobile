using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using MoreMobile.Application.Models;
using MoreMobile.Application.Services;
using MoreMobile.Resources.Core;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IServiceTypeService _serviceTypeService;

        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ServiceTypeDTO>>> GetAll()
        {
            return await _serviceTypeService.GetAll();
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceTypeDTO>> Get(Guid id)
        {
            var result = await _serviceTypeService.Get(id);

            if (result is null)
                return NotFound(CoreResource.ResourceManager.GetString(name: "ServiceTypeNotFound"));

            return Ok(result);
        }

        [HttpPost(), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid?>> Add(ServiceTypeDTO request)
        {
            var result = await _serviceTypeService.Add(request);

            return Ok(result);
        }

        [HttpPut(), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceTypeDTO>> Update(ServiceTypeDTO request)
        {
            var result = await _serviceTypeService.Update(request);

            if (result is null)
                return NotFound(CoreResource.ResourceManager.GetString(name: "ServiceTypeNotFound"));

            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _serviceTypeService.Delete(id);
            return Ok();
        }
    }
}