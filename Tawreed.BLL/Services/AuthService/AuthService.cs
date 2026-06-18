using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography;
using Tawreed.BLL.Constants;
using Tawreed.BLL.Contracts.Authentication;
using Tawreed.DAL.Data;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Services.AuthService;

public class AuthService(UserManager<ApplicationUser> userManager,IJwtProvider jwtProvider,
    ApplicationDbContext context) : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly ApplicationDbContext _context = context;

    private readonly int _refreshTokenExpiryDays = 14;


    // ── Login ────────────────────────────────────────────────────────────
    public async Task<AuthResponse?> GetTokenAsync(string email,string password,CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null) 
            return null;

        // block inactive (pending supplier approval)
        //if (!user.IsActive) 
        //    return null;

        var isValidPassword = await _userManager.CheckPasswordAsync(user, password);
        if (!isValidPassword)
            return null;

        var roles = await _userManager.GetRolesAsync(user);

        var (token, expiresIn) = _jwtProvider.GenerateToken(user, roles);
        
        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiration
        });
        await _userManager.UpdateAsync(user);

        return new AuthResponse(user.Id, user.Email, user.FullName, token, expiresIn, refreshToken, refreshTokenExpiration);
    }


    // ── Register Buyer ───────────────────────────────────────────────────
    public async Task<AuthResponse?> RegisterBuyerAsync(RegisterBuyerRequest request, CancellationToken cancellationToken = default)
    {
        var emailExists = await _userManager.Users
            .AnyAsync(u => u.Email == request.Email, cancellationToken);
        if (emailExists) 
            return null;

        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email,
            PhoneNumber = request.Phone,
            FullName = request.FullName,
            IsActive = true,   // buyers are active immediately
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded) return null;

        // assign buyer role
        await _userManager.AddToRoleAsync(user, AppRoles.Buyer);

        // create Buyer profile
        var buyer = new Buyer
        {
            UserId = user.Id,
            BusinessName = request.BusinessName,
            Address = request.Address,
            RegionId = request.RegionId,
            CreatedAt = DateTime.UtcNow,
        };

        await _context.Buyers.AddAsync(buyer);
        await _context.SaveChangesAsync(cancellationToken);

        var roles = await _userManager.GetRolesAsync(user);
        var (token, expiresIn) = _jwtProvider.GenerateToken(user, roles);
        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiration
        });

        return new AuthResponse(user.Id, user.Email, user.FullName, token, expiresIn, refreshToken, refreshTokenExpiration);
    }


    // ── Register Supplier ────────────────────────────────────────────────
    public async Task<AuthResponse?> RegisterSupplierAsync(RegisterSupplierRequest request, CancellationToken cancellationToken = default)
    {
        var emailExists = await _userManager.Users
            .AnyAsync(u => u.Email == request.Email, cancellationToken);
        if (emailExists) return null;

        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email,
            PhoneNumber = request.Phone,
            FullName = request.FullName,
            IsActive = false,  // suppliers are inactive until admin approves
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded) return null;

        // assign supplier role
        await _userManager.AddToRoleAsync(user, AppRoles.Supplier);

        // create Supplier profile
        var supplier = new Supplier
        {
            UserId = user.Id,
            CompanyName = request.CompanyName,
            TaxNumber = request.TaxId,
            CommercialRegister = request.CommercialRegister,
            CreatedAt = DateTime.UtcNow,
        };

        await _context.Suppliers.AddAsync(supplier);
        await _context.SaveChangesAsync(cancellationToken);
        // supplier gets no token — must wait for admin approval
        var roles = await _userManager.GetRolesAsync(user);
        var (token, expiresIn) = _jwtProvider.GenerateToken(user, roles);
        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiration
        });
        return new AuthResponse(user.Id, user.Email, user.FullName, token, expiresIn, refreshToken, refreshTokenExpiration);
    }



    public async Task<AuthResponse?> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = _jwtProvider.validateToken(token);
        if (userId is null)
            return null;

        var user = await _userManager.FindByIdAsync(userId);
        if(user is null)
            return null;

        var existedrefreshToken = user.RefreshTokens.FirstOrDefault(rt => rt.Token == refreshToken && rt.IsActive);
        if (existedrefreshToken is null)
            return null;

        existedrefreshToken.RevokedOn = DateTime.UtcNow;

        var roles = await _userManager.GetRolesAsync(user);
        var (newToken, expiresIn) = _jwtProvider.GenerateToken(user,roles);

        var newRefreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);
        user.RefreshTokens.Add(new RefreshToken
        {
            Token = newRefreshToken,
            ExpiresOn = refreshTokenExpiration
        });

        await _userManager.UpdateAsync(user);
        var response = new AuthResponse(user.Id, user.Email, user.FullName, newToken, expiresIn, newRefreshToken, refreshTokenExpiration);
        return response;
    }








    private static string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }
}