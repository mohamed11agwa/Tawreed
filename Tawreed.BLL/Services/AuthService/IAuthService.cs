using Microsoft.AspNetCore.Identity.Data;
using Tawreed.BLL.Contracts.Authentication;
using Tawreed.BLL.Shared;

namespace Tawreed.BLL.Services.AuthService;

public interface IAuthService
{
    Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<AuthResponse?> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
    Task<bool> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
    Task<Result<AuthResponse>> RegisterBuyerAsync(RegisterBuyerRequest request, CancellationToken cancellationToken = default);
    Task<Result<AuthResponse>> RegisterSupplierAsync(RegisterSupplierRequest request, CancellationToken cancellationToken = default);
}
