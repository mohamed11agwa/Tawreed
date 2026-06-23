using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawreed.DAL.Consts;
using Tawreed.DAL.Models;


namespace Tawreed.DAL.Configurations.UserConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.OwnsMany(x => x.RefreshTokens)
            .ToTable("RefreshTokens")
            .WithOwner()
            .HasForeignKey("UserId");



        //Default Data
        var passwordHasher = "AQAAAAIAAYagAAAAEPQRee3V73RVPNYD8BALbNHBr4xqPMVG+4GumW3asmZR8abwWUd7AJG8PQ1mnQs/uw==";
        builder.HasData(new ApplicationUser
        {
            Id = Guid.Parse(DefaultUsers.AdminId),
            FullName = "Admin",
            Status = "Active",
            PreferredLang = "en",
            CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            UserName = DefaultUsers.AdminEmail,
            NormalizedUserName = DefaultUsers.AdminEmail.ToUpper(),
            Email = DefaultUsers.AdminEmail,
            NormalizedEmail = DefaultUsers.AdminEmail.ToUpper(),
            SecurityStamp = DefaultUsers.AdminSecurityStamp,
            ConcurrencyStamp = DefaultUsers.AdminConcurrencyStamp,
            EmailConfirmed = true,
            PasswordHash = passwordHasher
        });
    }


}