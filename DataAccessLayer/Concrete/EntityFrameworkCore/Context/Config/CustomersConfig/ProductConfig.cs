using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Concrete.EntityFrameworkCore.Context.Config.CustomersConfig;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProductName).IsRequired();

        builder.Property(x => x.ProductDescription).HasColumnType("nText").IsRequired(false);
        builder.Property(x => x.UnitPrice).HasDefaultValue(0);
        builder.Property(x => x.Quantity).HasDefaultValue(0);
        
        builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        builder.HasMany(x => x.Colors).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
    }
}
