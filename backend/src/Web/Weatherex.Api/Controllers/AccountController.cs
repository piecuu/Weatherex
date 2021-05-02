using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weatherex.Application.Dto;
using Weatherex.Infrastructure.Identity;

namespace Weatherex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }   

        [HttpPost("auth")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationDto authRequest)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.UserName == authRequest.UserName);

            if (user is null)
            {
                return NotFound("User not found.");
            }

            var authResult = await _userManager.CheckPasswordAsync(user, authRequest.Password);

            if (authResult)
            {
                return Ok();
            }

            return BadRequest("Invalid username or password.")
        }
    }
}
