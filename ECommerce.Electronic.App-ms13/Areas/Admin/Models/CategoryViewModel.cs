using BusinessLogic.Models.CategoryModels;

namespace ECommerce.Electronic.App_ms13.Areas.Admin.Models;

public class CategoryViewModel
{
    public CategoryViewModel()
    {
        CategoryModels = new List<CategoryModel>();
    }
    public int? CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public IEnumerable<CategoryModel> CategoryModels { get; set; }
}
