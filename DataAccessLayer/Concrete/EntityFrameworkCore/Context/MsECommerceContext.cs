using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccessLayer.Concrete.EntityFrameworkCore.Context;

public class MsECommerceContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.;Database=MsECommerce;Trusted_Connection=true;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
