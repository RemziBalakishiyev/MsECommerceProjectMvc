using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.ProductModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public ICollection<ColorModel> Colors { get; set; }
       
    }
}
