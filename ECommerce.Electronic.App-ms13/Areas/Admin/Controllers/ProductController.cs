using BusinessLogic.Abstract;
using BusinessLogic.Concrete.Customers;
using BusinessLogic.Models.CategoryModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Electronic.App_ms13.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;

        //  p(new SubCategoryService())
        public ProductController(ICategoryService categoryService) // == new CategoryService()
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


        public async Task<IActionResult> Category()
        {
            var categories = await _categoryService.GetAll();
            return View(categories);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel categoryModel)
        {
            var result = await _categoryService.AddCategory(categoryModel);

            return RedirectToAction(nameof(Category));
        }
    }
}
