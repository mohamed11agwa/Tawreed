namespace Tawreed.BLL.Contracts.Authentication;

public record RegisterRequest(
    string Email,
    string Password,
    string FullName
);
