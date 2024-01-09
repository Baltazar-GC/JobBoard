using backend.Contexts;
using backend.Entities;
using backend.Models.Auth;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.Implementations
{


    public class RefreshTokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly IJwtGeneratorService _jwtGeneratorService;
        private readonly ApplicationUtnContext _context;
        private readonly ILogger<RefreshTokenCommand> _logger;


        public RefreshTokenService(IConfiguration config, UserManager<User> userManager, IJwtGeneratorService jwtGeneratorService, ApplicationUtnContext context, ILogger<RefreshTokenCommand> logger)
        {
            _config = config;
            _userManager = userManager;
            _jwtGeneratorService = jwtGeneratorService;
            _context = context;
            _logger = logger;
        }



        public async Task<RefreshTokenCommand?> Handle(TokenModel request)
        {
            var refreshToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(q => q.RefreshTokenValue == request.RefreshToken);


            if (refreshToken is null ||
                refreshToken.Active == false ||
                refreshToken.Expiration <= DateTime.UtcNow)
            {
                return null;
            }


            if (refreshToken.Used)
            {
                _logger.LogWarning("El refresh token del ${UserId} ya fue usado. RT={RefreshToken}", refreshToken.UserId, refreshToken.RefreshTokenValue);

                var refreshTokens = await _context.RefreshTokens
                    .Where(q => q.Active && q.Used == false && q.UserId == refreshToken.UserId)
                    .ToListAsync();

                foreach (var rt in refreshTokens)
                {
                    rt.Used = true;
                    rt.Active = false;
                }

                _context.SaveChanges();

                return null;
            }


            refreshToken.Used = true;

            var user = _context.Users.Find(refreshToken.UserId);

            if (user is null)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);

            var jwt = _jwtGeneratorService.GenerateAuthToken(user, roles);

            var newRefreshToken = new RefreshToken
            {
                Active = true,
                Expiration = DateTime.UtcNow.AddDays(1),
                RefreshTokenValue = Guid.NewGuid().ToString("N"),
                Used = false,
                UserId = user.Id
            };

            await _context.AddAsync(newRefreshToken);

            await _context.SaveChangesAsync();

            return new RefreshTokenCommand
            {
                AccessToken = jwt.AccessToken,
                RefreshToken = newRefreshToken.RefreshTokenValue
            };


        }
        public class RefreshTokenCommand
        {
            public string AccessToken { get; set; } = default!;
            public string RefreshToken { get; set; } = default!;
        }
    }
}