using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoreMobile.Domain.Entities;
using MoreMobile.Resources.Core;

namespace MoreMobile.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(SignInManager<User> sm, UserManager<User> um)
        {
            _signInManager = sm;
            _userManager = um;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(User user)
        {
            IdentityResult result = new();

            try
            {
                User user_ = new User()
                {
                    Email = user.Email
                };

                result = await _userManager.CreateAsync(user_, user.PasswordHash);

                if (!result.Succeeded)
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(CoreResource.ResourceManager.GetString(name: "TryAgain") + ex.Message);
            }

            return Ok(new { message = CoreResource.ResourceManager.GetString(name: "RegisteredSuccessfully"), result = result });
        }
    }
}