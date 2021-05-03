namespace Weatherex.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateJwtToken(string userId);
    }
}
