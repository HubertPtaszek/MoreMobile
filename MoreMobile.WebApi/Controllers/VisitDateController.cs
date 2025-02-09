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
    public class VisitDateController : ControllerBase
    {
        private readonly IVisitDateService _visitDateService;

        public VisitDateController(IVisitDateService visitDateService)
        {
            _visitDateService = visitDateService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<VisitDateDTO>>> GetAll()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return await _visitDateService.GetAll();
        }

        [HttpGet("getUserWarranties"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<VisitDateDTO>>> GetUserAll()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return await _visitDateService.GetUserAll(Guid.Parse(claims.Value));
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<VisitDateDTO>> Get(Guid id)
        {
            var result = await _visitDateService.Get(id);

            if (result is null)
                return NotFound(CoreResource.ResourceManager.GetString(name: "VisitDateNotFound"));

            return Ok(result);
        }

        [HttpPost(), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid?>> Add(VisitDateDTO request)
        {
            var result = await _visitDateService.Add(request);

            return Ok(result);
        }

        [HttpPut(), Authorize(Roles = "Admin")]
        public async Task<ActionResult<VisitDateDTO>> Update(VisitDateDTO request)
        {
            var result = await _visitDateService.Update(request);

            if (result is null)
                return NotFound(CoreResource.ResourceManager.GetString(name: "VisitDateNotFound"));

            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _visitDateService.Delete(id);
            return Ok();
        }
    }
}