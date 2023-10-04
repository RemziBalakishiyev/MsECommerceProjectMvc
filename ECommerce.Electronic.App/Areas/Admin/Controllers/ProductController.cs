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

            var categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = await _categoryService.GetAll();
            return View(categoryViewModel);
        }   

        public async Task<IActionResult> AddCategory(CategoryModel categoryModel)
        {

            if (!ModelState.IsValid)
            {
                var categoryViewModel = new CategoryViewModel();
                categoryViewModel.CategoryName = categoryModel.CategoryName;
                categoryViewModel.Id = categoryModel.Id;
                return RedirectToAction(nameof(Category), categoryViewModel);
            }
          
            await _categoryService.AddNewCategory(categoryModel);
            return RedirectToAction(nameof(Category));
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductModel addProductModel)
        {
            var resultModel =  _productService.AddProduct(addProductModel);
            return View();
        }

        [HttpGet]
        public JsonResult GetCatgoryById(int id)
        {
            var resultModel = _categoryService.GetById(id);
            return Json(resultModel);
        }
    }
}
