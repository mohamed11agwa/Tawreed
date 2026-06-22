namespace Tawreed.BLL.Contracts.Authentication;

public record RefreshTokenRequest(
    string Token,
    string RefreshToken
 );

