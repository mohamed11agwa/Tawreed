using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tawreed.BLL.Contracts.Authentication;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Services.AuthService;

public class AuthService(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider) : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<AuthResponse?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        //check user
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return null;
        //check password
        var isvalidPassword = await _userManager.CheckPasswordAsync(user, password);
        if(!isvalidPassword)
            return null;


        //Generate token
        var (token, expiresIn) = _jwtProvider.GenerateToken(user);
        return new AuthResponse(user.Id, user.Email, user.FullName, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImlhdCI6MTUxNjIzOTAyMn0.KMUFsIDTnFmyG3nMiGM6H9FNFUROf3wh7SmqJp-QV30", 3600);
    }

    public async Task<AuthResponse?> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var emailIsExists = await _userManager.Users.AnyAsync(x => x.Email == request.Email, cancellationToken);
        if (emailIsExists)
            return null;
        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email,
            FullName = request.FullName,
        };
        var result = await _userManager.CreateAsync(user, request.Password);
        if(result.Succeeded)
        {
            var (token, expiresIn) = _jwtProvider.GenerateToken(user);
            await _userManager.UpdateAsync(user);

            var response = new AuthResponse(user.Id, user.Email, user.FullName, token, expiresIn);
            
            return response;
        }
        return null;

    }
}
