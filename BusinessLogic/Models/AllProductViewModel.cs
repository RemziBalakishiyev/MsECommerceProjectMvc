namespace BusinessLogic.Models
{
    public class AllProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public bool InStock { get; set; }
        public string CategoryName { get; set; } = string.Empty;

    }
}
