using BusinessLogic.Abstract;
using BusinessLogic.Models;
using ECommerce.Electronic.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Electronic.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View(new AddProductModel());
        }

        public async Task<IActionResult> Category()
        {

            List<CategoryViewModel> categories = new List<CategoryViewModel>();

            foreach (var ctg in await _categoryService.GetAll())
            {
                CategoryViewModel categoryViewModel = new()
                {
                    Id = ctg.Id ?? 0,
                    CategoryName = ctg.CategoryName,
                };
                categories.Add(categoryViewModel);
            }
            
            return View(categories);
        }

        public async Task<IActionResult> AddCategory(CategoryViewModel categoryViewModel)
        {

            CategoryModel categoryModel = new CategoryModel()
            {
                Id = categoryViewModel.Id,
                CategoryName = categoryViewModel.CategoryName,
            };
            await _categoryService.AddNewCategory(categoryModel);
            return RedirectToAction(nameof(Category));
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductModel addProductModel)
        {

            var resultModel =  _productService.AddProduct(addProductModel);
            return View();
        }
    }
}
