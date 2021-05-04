using System.ComponentModel.DataAnnotations;

namespace Weatherex.Application.Account
{
    public class AuthenticationRequest
    {
        [Required]
        //[JsonPropertyAttribute("username")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
