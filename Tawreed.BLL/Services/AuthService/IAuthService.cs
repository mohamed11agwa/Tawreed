using Tawreed.BLL.Contracts.Authentication;

namespace Tawreed.BLL.Services.AuthService;

public interface IAuthService
{
    Task<AuthResponse?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<AuthResponse?> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
}
