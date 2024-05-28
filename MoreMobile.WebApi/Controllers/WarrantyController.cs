using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using MoreMobile.Application.Models;
using MoreMobile.Application.Services;
using MoreMobile.Resources.Core;
using System.Security.Claims;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarrantyController : ControllerBase
    {
        private readonly IWarrantyService _warrantyService;

        public WarrantyController(IWarrantyService warrantyService)
        {
            _warrantyService = warrantyService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<WarrantyDTO>>> GetAll()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return await _warrantyService.GetAll();
        }

        [HttpGet("getUserWarranties"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<WarrantyDTO>>> GetUserAll()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return await _warrantyService.GetUserAll(Guid.Parse(claims.Value));
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<WarrantyDTO>> Get(Guid id)
        {
            var result = await _warrantyService.Get(id);

            if (result is null)
                return NotFound(CoreResource.ResourceManager.GetString(name: "WarrantyNotFound"));

            return Ok(result);
        }

        [HttpPost(), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid?>> Add(WarrantyDTO request)
        {
            var result = await _warrantyService.Add(request);

            return Ok(result);
        }

        [HttpPut(), Authorize(Roles = "Admin")]
        public async Task<ActionResult<WarrantyDTO>> Update(WarrantyDTO request)
        {
            var result = await _warrantyService.Update(request);

            if (result is null)
                return NotFound(CoreResource.ResourceManager.GetString(name: "WarrantyNotFound"));

            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _warrantyService.Delete(id);
            return Ok();
        }
    }
}