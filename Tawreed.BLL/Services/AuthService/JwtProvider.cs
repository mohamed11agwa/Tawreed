using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Services.AuthService;

public class JwtProvider(IOptions<JwtOptions> jwtOptions) : IJwtProvider
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public (string token, int expiresIn) GenerateToken(ApplicationUser user)
    {
        Claim[] claims = [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ];
        var symmertricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
        var signingCredentials = new SigningCredentials(symmertricSecurityKey, SecurityAlgorithms.HmacSha256);


        var expirationDate = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpireMinutes);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: expirationDate,
            signingCredentials: signingCredentials
            );
        return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIn: _jwtOptions.ExpireMinutes * 60);

    }

   
}
