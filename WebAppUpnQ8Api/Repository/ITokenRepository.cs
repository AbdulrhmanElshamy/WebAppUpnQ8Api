using System.Security.Claims;
using WebAppUpnQ8Api.Models;

namespace WebAppUpnQ8Api.Repository
{
    public interface ITokenRepository
    {
        public string GenerateAccessToken(ApplicationUser user);
        public string GenerateRefreshToken();
        public ClaimsPrincipal GetPrincipalExpiredToken(string token);
      
    }
}
