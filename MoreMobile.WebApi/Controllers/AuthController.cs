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
        private readonly SignInManager<UserBase> _signInManager;
        private readonly UserManager<UserBase> _userManager;

        public AuthController(SignInManager<UserBase> sm, UserManager<UserBase> um)
        {
            _signInManager = sm;
            _userManager = um;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(UserBase user)
        {
            IdentityResult result = new();

            try
            {
                UserBase user_ = new UserBase()
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