using BusinessLogic.Models;

namespace ECommerce.Electronic.App.Models;

public class CategoryViewModel
{
    public CategoryViewModel()
    {
        Categories = new List<CategoryModel>();
    }
    public IEnumerable<CategoryModel> Categories { get; set; }
    public int? Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
