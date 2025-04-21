using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAppUpnQ8Api.Models;
using WebAppUpnQ8Api.Repository;

namespace WebAppUpnQ8Api.RepositoryModels
{
    public class TokenRepository : ITokenRepository
    {
        private readonly string? _secretKey;
        private readonly string? _issuer;
        private readonly string? _audience;
        private readonly int _accessTokenExpirationMinutes;
        private readonly int _refreshTokenExpirationDays;

        public TokenRepository(IConfiguration configuration)
        {
            _secretKey = configuration["JwtSettings:SecretKey"];
            _issuer = configuration["JwtSettings:Issuer"];
            _audience = configuration["JwtSettings:Audience"];
            _accessTokenExpirationMinutes = int.Parse(configuration["JwtSettings:AccessTokenExpirationMinutes"]);
            _refreshTokenExpirationDays = int.Parse(configuration["JwtSettings:RefreshTokenExpirationDays"]);
        }
        public string GenerateAccessToken(ApplicationUser user)
        {
            var claims = new[]
     {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Name, user.UserName), 
         new Claim(ClaimTypes.Email, user.Email),
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_accessTokenExpirationMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var refreshToken = Guid.NewGuid().ToString();
            return refreshToken;
        }

        public ClaimsPrincipal GetPrincipalExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            return principal;
        }
    }
}
