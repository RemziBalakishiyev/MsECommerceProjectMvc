namespace BusinessLogic.Models;

public class AddProductModel
{
  
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Size { get; set; }
    public int CategoryId { get; set; }
    public List<ColorModel> ColorModels { get; set; }
}

public class ColorModel
{
    public string ColorCode { get; set; }
}
