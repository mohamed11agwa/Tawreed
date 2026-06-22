using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawreed.DAL.Models;

namespace Tawreed.DAL.Configuration;

public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
{
    public void Configure(EntityTypeBuilder<Buyer> builder)
    {
        builder.HasKey(s => s.UserId);

        builder.HasOne(s => s.User)
            .WithOne(u => u.Buyer)
            .HasForeignKey<Buyer>(s => s.UserId);
    }
}
