namespace Tawreed.BLL.Contracts.Authentication;

public record LoginRequest(
  string Email,
  string Password
);
