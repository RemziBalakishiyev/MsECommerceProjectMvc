using Entity.Abstract;

namespace Entity.Concrete.Customer;

public class Category:IBaseTable
{

    public Category()
    {
        Products = new HashSet<Product>();
    }
    public int Id { get; set; }
    public string CategoryName { get; set; } = String.Empty;
    public ICollection<Product> Products { get; set; }
}
