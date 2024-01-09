
using backend.Contexts;
using backend.Entities;
using backend.Models.Auth;
using backend.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Services.Implementations
{
    public class JwtGeneratorService : IJwtGeneratorService
    {
        private readonly IConfiguration _config;
        private readonly ApplicationUtnContext _context;


        public JwtGeneratorService(IConfiguration config, ApplicationUtnContext context)
        {
            _config = config;
            _context = context;
        }

        public TokenCommandResponse? GenerateAuthToken(User user, ICollection<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}")
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);


            var newAccessToken = new RefreshToken
            {
                Active = true,
                Expiration = DateTime.UtcNow.AddDays(1),
                RefreshTokenValue = Guid.NewGuid().ToString("N"),
                Used = false,
                UserId = user.Id
            };

            _context.Add(newAccessToken);

            _context.SaveChanges();

            return new TokenCommandResponse
            {
                AccessToken = jwt,
                RefreshToken = newAccessToken.RefreshTokenValue
            };

        }

        public class TokenCommandResponse
        {
            public string AccessToken { get; set; } = default!;
            public string RefreshToken { get; set; } = default!;
        }
    }
}
