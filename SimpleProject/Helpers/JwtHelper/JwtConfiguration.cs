using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleProject.Helpers.JwtHelper
{
    public class JwtConfiguration
    {
        private readonly IConfiguration _configuration;

        public JwtConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string username, decimal balance, string email)
        {
            var jwtSettings = new JwtSettings();
            _configuration.GetSection("JwtSettings").Bind(jwtSettings);

            var claims = new[]
            {
            new Claim("username", username),
            new Claim("balance", balance.ToString()),
            new Claim("email", email)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               issuer: jwtSettings.Issuer,
               audience: jwtSettings.Audience,
               claims: claims,
               expires: DateTime.UtcNow.AddHours(1),
               signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
           );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
