namespace Tawreed.BLL.Contracts.Authentication;

public record AuthResponse(
    Guid Id,
    string? Eamil,
    string FullName,
    string Token,
    int ExpiresIn
);
