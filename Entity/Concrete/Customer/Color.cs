using Entity.Abstract;

namespace Entity.Concrete.Customer;

public class Color: IBaseTable
{
    public Color()
    {
        ProductColors = new HashSet<ProductColor>();
    }
    public int Id { get; set; }
    public string ColorName { get; set; }=string.Empty;
    public string ColorCode { get; set; }=string.Empty ;
    public ICollection<ProductColor> ProductColors { get; set; }
}
