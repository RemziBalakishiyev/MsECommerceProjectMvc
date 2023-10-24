using Entity.Concrete.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Concrete.EntityFrameworkCore.Context.Config.CustomersConfig;

public class ColorConfig : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ColorName).IsRequired(false);
        builder.Property(x=>x.ColorCode).IsRequired();
   
    }
}
