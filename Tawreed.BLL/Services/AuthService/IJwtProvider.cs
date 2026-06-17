using Tawreed.DAL.Models;

namespace Tawreed.BLL.Services.AuthService;

public interface IJwtProvider
{
    (string token, int expiresIn) GenerateToken(ApplicationUser user);
}
