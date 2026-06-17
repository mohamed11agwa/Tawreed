using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Services.AuthService;

public class JwtProvider : IJwtProvider
{
    public (string token, int expiresIn) GenerateToken(ApplicationUser user)
    {
        Claim[] claims = [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ];
        var symmertricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KUtx6ixpTmrdEeIA06cmMzjJc8xNZhYr6SBBAd0PPTt"));
        var signingCredentials = new SigningCredentials(symmertricSecurityKey, SecurityAlgorithms.HmacSha256);

        var expiresIn = 30;

        var expirationDate = DateTime.UtcNow.AddMinutes(expiresIn);

        var token = new JwtSecurityToken(
            issuer: "TawreedApp",
            audience: "Tawreed.users",
            claims: claims,
            expires: expirationDate,
            signingCredentials: signingCredentials
            );
        return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIn: expiresIn * 60);

    }

   
}
