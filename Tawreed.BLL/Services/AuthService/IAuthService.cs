using Tawreed.BLL.Contracts.Authentication;

namespace Tawreed.BLL.Services.AuthService;

public interface IAuthService
{
    Task<AuthResponse?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<AuthResponse?> RegisterBuyerAsync(RegisterBuyerRequest request, CancellationToken cancellationToken = default);
    Task<AuthResponse?> RegisterSupplierAsync(RegisterSupplierRequest request, CancellationToken cancellationToken = default);
    Task<AuthResponse?> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
}
