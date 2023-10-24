using BusinessLogic.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.ProductModels
{
    public class GetAllProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public string InStock { get; set; }
        public CategoryModel Category { get; set; }
        public string ImagePath { get; set; }
        public ICollection<ColorModel> Colors { get; set; }
    }
}
