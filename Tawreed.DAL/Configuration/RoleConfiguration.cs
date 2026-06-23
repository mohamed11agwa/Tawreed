using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawreed.DAL.Consts;
using Tawreed.DAL.Models;


namespace Tawreed.DAL.Configurations.UserConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        //Default Data

        builder.HasData([
            new ApplicationRole{
                Id = Guid.Parse(DefaultRoles.AdminRoleId),
                Name = DefaultRoles.Admin,
                NormalizedName = DefaultRoles.Admin.ToUpper(),
                ConcurrencyStamp = DefaultRoles.AdminRoleConcurrencyStamp
            },
            new ApplicationRole{
                Id = Guid.Parse(DefaultRoles.BuyerRoleId),
                Name = DefaultRoles.Buyer,
                NormalizedName = DefaultRoles.Buyer.ToUpper(),
                ConcurrencyStamp = DefaultRoles.BuyerRoleConcurrencyStamp
            },
            new ApplicationRole{
                Id = Guid.Parse(DefaultRoles.SupplierRoleId),
                Name = DefaultRoles.Supplier,
                NormalizedName = DefaultRoles.Supplier.ToUpper(),
                ConcurrencyStamp = DefaultRoles.SupplierRoleConcurrencyStamp
            }
         ]);
    }


}