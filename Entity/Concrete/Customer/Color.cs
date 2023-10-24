using Entity.Abstract;

namespace Entity.Concrete.Customer;

public class Color : IBaseTable
{

    public int Id { get; set; }
    public string ColorName { get; set; } = string.Empty;
    public string ColorCode { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
