using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tawreed.BLL.Constants;
using Tawreed.BLL.Contracts.Authentication;
using Tawreed.DAL.Data;
using Tawreed.DAL.Models;

namespace Tawreed.BLL.Services.AuthService;

public class AuthService(
    UserManager<ApplicationUser> userManager,
    IJwtProvider jwtProvider,
    ApplicationDbContext context) : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly ApplicationDbContext _context = context;


    // ── Login ────────────────────────────────────────────────────────────
    public async Task<AuthResponse?> GetTokenAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null) return null;

        // block inactive (pending supplier approval)
        if (!user.IsActive) return null;

        var isValidPassword = await _userManager.CheckPasswordAsync(user, password);
        if (!isValidPassword) return null;

        var roles = await _userManager.GetRolesAsync(user);
        var (token, expiresIn) = _jwtProvider.GenerateToken(user, roles);

        return new AuthResponse(user.Id, user.Email, user.FullName, token, expiresIn);
    }

    // ── Register Buyer ───────────────────────────────────────────────────
    public async Task<AuthResponse?> RegisterBuyerAsync(
        RegisterBuyerRequest request,
        CancellationToken cancellationToken = default)
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

        return new AuthResponse(user.Id, user.Email, user.FullName, token, expiresIn);
    }

    // ── Register Supplier ────────────────────────────────────────────────
    public async Task<AuthResponse?> RegisterSupplierAsync(
        RegisterSupplierRequest request,
        CancellationToken cancellationToken = default)
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
        return new AuthResponse(user.Id, user.Email, user.FullName, string.Empty, 0);
    }
}