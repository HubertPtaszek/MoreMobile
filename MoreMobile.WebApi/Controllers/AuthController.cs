using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoreMobile.Domain.Entities;

namespace MoreMobile.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager ;
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
                return BadRequest("Something went wrong, please try again. " + ex.Message);
            }

            return Ok(new { message = "Registered Successfully.", result = result });
        }

    }
}
