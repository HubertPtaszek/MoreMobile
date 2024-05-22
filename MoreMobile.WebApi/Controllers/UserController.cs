using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoreMobile.Application.Models;
using MoreMobile.Application.Services;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<List<UserDTO>>> GetAllTrips()
        {
            return await _userService.GetAll();
        }

        [HttpGet("{email}"), Authorize]
        public async Task<ActionResult<UserDTO>> GetTrip(string email)
        {
            var result = await _userService.Get(email);
            if (result is null)
                return NotFound("User not found.");

            return Ok(result);
        }

        [HttpPut(), Authorize]
        public async Task<ActionResult<List<UserDTO>>> Update(UserDTO request)
        {
            var result = await _userService.Update(request);
            if (result is null)
                return NotFound("User not found.");

            return Ok(result);
        }

        [HttpDelete("{email}"), Authorize]
        public async Task<ActionResult<List<UserDTO>>> Delete(string email)
        {
            await _userService.Delete(email);
            return Ok();
        }
    }
}
