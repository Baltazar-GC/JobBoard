using backend.Entities;
using static backend.Services.Implementations.JwtGeneratorService;

namespace backend.Services.Interfaces
{
    public interface IJwtGeneratorService
    {
        public TokenCommandResponse? GenerateAuthToken(User user, ICollection<string> roles);
    }
}
