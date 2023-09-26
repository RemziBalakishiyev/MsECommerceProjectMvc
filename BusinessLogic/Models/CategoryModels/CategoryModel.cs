using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.CategoryModels;

public class CategoryModel
{
    public int? Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
