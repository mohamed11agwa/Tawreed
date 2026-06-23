using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Tawreed.BLL.Contracts.Authentication;
using Tawreed.BLL.Shared;
using Tawreed.BLL.Shared.Errors;
using Tawreed.DAL.Consts;
using Tawreed.DAL.Data;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Services.AuthService;

public class AuthService(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider,
    ApplicationDbContext context) : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly ApplicationDbContext _context = context;

    private readonly int _refreshTokenExpirationDays = 14;

    public async Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        //Check user
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

        //// block inactive (pending supplier approval)
        //if (!user.IsActive) return null;

        //check password
        var isValidPassword = await _userManager.CheckPasswordAsync(user, password);
        if (!isValidPassword)
            return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

        //var roles = await _userManager.GetRolesAsync(user);
        //generate token
        var (token, expiresIn) = _jwtProvider.GenerateToken(user);
        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpirationDays);
        //save RefreshToken Into Db
        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiration,
        });
        await _userManager.UpdateAsync(user);
        var response = new AuthResponse(user.Id, user.Email, user.FullName, token, expiresIn, refreshToken, refreshTokenExpiration);
        
        return Result.Success(response);
    }



    public async Task<AuthResponse?> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = _jwtProvider.ValidateToken(token);
        if (userId is null)
            return null;
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            return null;

        var existingRefreshToken = user.RefreshTokens.FirstOrDefault(rt => rt.Token == refreshToken && rt.IsActive);

        if (existingRefreshToken is null)
            return null;
        existingRefreshToken.RevokedOn = DateTime.UtcNow;


        //Generate new jwt Token
        var (newToken, expiresIn) = _jwtProvider.GenerateToken(user);

        var newRefreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpirationDays);
        user.RefreshTokens.Add(new RefreshToken
        {
            Token = newRefreshToken,
            ExpiresOn = refreshTokenExpiration,
        });
        await _userManager.UpdateAsync(user);


        var response = new AuthResponse(user.Id, user.Email, user.FullName, newToken, expiresIn, newRefreshToken, refreshTokenExpiration);
        return (response);
    }


    public async Task<bool> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = _jwtProvider.ValidateToken(token);
        if (userId is null)
            return false;
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            return false;
        var existingRefreshToken = user.RefreshTokens.FirstOrDefault(rt => rt.Token == refreshToken && rt.IsActive);

        if (existingRefreshToken is null)
            return false;
        existingRefreshToken.RevokedOn = DateTime.UtcNow;
        await _userManager.UpdateAsync(user);

        return true;
    }


    // ── Register Buyer ───────────────────────────────────────────────────
    public async Task<Result<AuthResponse>> RegisterBuyerAsync(RegisterBuyerRequest request, CancellationToken cancellationToken = default)
    {
        var emailExists = await _userManager.Users.AnyAsync(u => u.Email == request.Email, cancellationToken);
        if (emailExists) 
            return Result.Failure<AuthResponse>(UserErrors.DuplicatedEmail);

        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email,
            PhoneNumber = request.Phone,
            FullName = request.FullName,
            PreferredLang = request.PreferredLang,
            Status = "Active"
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var error = result.Errors.First();
            return Result.Failure<AuthResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
        }

        // assign buyer role
        await _userManager.AddToRoleAsync(user, DefaultRoles.Buyer);

        // create Buyer profile
        var buyer = new Buyer
        {
            UserId = user.Id,
            BusinessName = request.BusinessName,
            BusinessType = request.BusinessType,
            RatingAvg = request.RatingAvg,
            TaxNumber = request.TaxNumber,
            Longitude = request.Longitude,
            Latitude = request.Latitude,
            Address = request.Address,
            RegionId = request.RegionId,
            CreatedAt = DateTime.UtcNow,
        };

        await _context.Buyers.AddAsync(buyer);
        await _context.SaveChangesAsync(cancellationToken);

        //var roles = await _userManager.GetRolesAsync(user);
        var (token, expiresIn) = _jwtProvider.GenerateToken(user);
        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpirationDays);
        //save RefreshToken Into Db
        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiration,
        });
        await _userManager.UpdateAsync(user);
        
        var response = new AuthResponse(user.Id, user.Email, user.FullName, token, expiresIn, refreshToken, refreshTokenExpiration);
        return Result.Success<AuthResponse>(response);
    }





    // ── Register Supplier ────────────────────────────────────────────────
    public async Task<Result<AuthResponse>> RegisterSupplierAsync(RegisterSupplierRequest request, CancellationToken cancellationToken = default)
    {
        var emailExists = await _userManager.Users.AnyAsync(u => u.Email == request.Email, cancellationToken);
        if (emailExists)
            return Result.Failure<AuthResponse>(UserErrors.DuplicatedEmail);

        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email,
            PhoneNumber = request.Phone,
            FullName = request.FullName,
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var error = result.Errors.First();
            return Result.Failure<AuthResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
        }

        // assign supplier role
        //await _userManager.AddToRoleAsync(user, AppRoles.Supplier);

        // create Supplier profile
        var supplier = new Supplier
        {
            UserId = user.Id,
            CompanyName = request.CompanyName,
            TaxNumber = request.TaxId,
            CreatedAt = DateTime.UtcNow,
        };

        await _context.Suppliers.AddAsync(supplier);
        await _context.SaveChangesAsync(cancellationToken);

        // supplier gets no token — must wait for admin approval
        //var roles = await _userManager.GetRolesAsync(user);
        var (token, expiresIn) = _jwtProvider.GenerateToken(user);

        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpirationDays);
        //save RefreshToken Into Db
        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiration,
        });
        await _userManager.UpdateAsync(user);
        
        var response = new AuthResponse(user.Id, user.Email, user.FullName, token, expiresIn, refreshToken, refreshTokenExpiration);
        return Result.Success(response);
    }



    private static string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }
}