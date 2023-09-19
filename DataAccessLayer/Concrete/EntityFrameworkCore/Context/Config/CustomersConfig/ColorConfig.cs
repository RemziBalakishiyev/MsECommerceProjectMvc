using Entity.Concrete.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Concrete.EntityFrameworkCore.Context.Config.CustomersConfig;

public class ColorConfig : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ColorName).IsRequired();
        builder.Property(x=>x.ColorCode).IsRequired();
        builder.HasMany(x => x.ProductColors).WithOne(x => x.Color).HasForeignKey(x => x.ColorId);
    }
}
