using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Weatherex.Application.Account;
using Weatherex.Application.Interfaces;
using Weatherex.Infrastructure.Identity;

namespace Weatherex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }   

        [HttpPost("auth")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest authRequest)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.UserName == authRequest.UserName);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var authResult = await _userManager.CheckPasswordAsync(user, authRequest.Password);

            if (!authResult)
            {
                return BadRequest("Invalid username or password.");
            }

            var token = _tokenService.CreateJwtToken(user.Id);

            return new JsonResult(token);
        }
    }
}
