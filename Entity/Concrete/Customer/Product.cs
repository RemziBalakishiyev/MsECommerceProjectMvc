using Entity.Abstract;
using Entity.Concrete.Customer;

namespace Entity.Concrete;

public class Product:IBaseTable
{
    public Product()
    {
        ProductColors = new HashSet<ProductColor>();
    }
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Size { get; set; }
    public int Quantity { get; set; }
    public bool InStock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<ProductColor> ProductColors { get; set; }

}
