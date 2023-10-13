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


        [HttpGet]
        public async Task<JsonResult> GetCategories()
        {
            var categories = await _categoryService.GetAll();
            return Json(categories);
        }

 

        [HttpPost]
        public JsonResult AddProduct([FromBody]  AddProductModel addProductModel)
        {

            if (ModelState.IsValid)
            {
                var resultModel = _productService.AddProduct(addProductModel);
                return Json(new {message="Product added successfully" });
            }
            return Json("");

     
        }

        [HttpGet]
        public JsonResult GetCatgoryById(int id)
        {
            var resultModel = _categoryService.GetById(id);
            return Json(resultModel);
        }
    }
}
