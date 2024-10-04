using Microsoft.AspNetCore.Identity;

namespace DotNetCore_API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
