using M008_Authentication.Data;

namespace M008_Authentication.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}