namespace Tawreed.BLL.Contracts.Authentication;

public record AuthResponse(
    Guid Id,
    string? Email,
    string FullName,
    string Token,
    int ExpiresIn,
    string RefreshToken,
    DateTime RefreshTokenExpiration
);
