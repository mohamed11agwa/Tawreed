namespace Tawreed.BLL.Contracts.Authentication;

public record RefreshTokenRequest(
   string token,
   string refreshToken
 );
