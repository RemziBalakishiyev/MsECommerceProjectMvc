using BusinessLogic.Abstract;
using BusinessLogic.Concrete.Customers;
using BusinessLogic.Models.CategoryModels;
using ECommerce.Electronic.App_ms13.Areas.Admin.Models;
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

            CategoryViewModel categoryViewModel = new();
            categoryViewModel.CategoryModels = await _categoryService.GetAll();

            return View(categoryViewModel);
        }



        [HttpPost]
        public async Task<IActionResult> AddProduct(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.AddCategory(categoryModel);
                return RedirectToAction(nameof(Category));
            }

            CategoryViewModel categoryViewModel = new();
            categoryViewModel.CategoryName = categoryModel.CategoryName;
            return RedirectToAction(nameof(Category), categoryViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.AddCategory(categoryModel);
                return RedirectToAction(nameof(Category));
            }

            CategoryViewModel categoryViewModel = new();
            categoryViewModel.CategoryName = categoryModel.CategoryName;
            return RedirectToAction(nameof(Category), categoryViewModel);

        }

        [HttpGet]
        public async Task<JsonResult> DeleteCategory(int id)
        {
            var isDelete = await _categoryService.Remove(id);

            if (isDelete)
            {
                return Json(new {message="Category is Deleted" });
            }

            return Json(new { message = "Category isnot  Deleted" });
        }
    }
}
