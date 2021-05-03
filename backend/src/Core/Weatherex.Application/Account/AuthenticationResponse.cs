using Weatherex.Application.Dto;

namespace Weatherex.Application.Account
{
    public class AuthenticationResponse
    {
        public AccountDto Account { get; set; }

        public string Token { get; set; }
    }
}
