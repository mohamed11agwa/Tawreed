using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawreed.DAL.Consts;


namespace Tawreed.DAL.Configurations.UserConfigurations;

public class RoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
    {

        var permissions = Permissions.GetAllPermissions();
        var adminClaims = new List<IdentityRoleClaim<Guid>>();

        //Default Data
        for(var i = 0; i < permissions.Count; i++)
        {
            adminClaims.Add(new IdentityRoleClaim<Guid>()
            {
                Id = i + 1,
                ClaimType = Permissions.Type,
                ClaimValue = permissions[i],
                RoleId = Guid.Parse(DefaultRoles.AdminRoleId)
            });
        }
        builder.HasData(adminClaims);
    }


}