using BusinessLogic.Abstract;
using BusinessLogic.Concrete.Customers;
using BusinessLogic.Models.CategoryModels;
using BusinessLogic.Models.ProductModels;
using ECommerce.Electronic.App_ms13.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Electronic.App_ms13.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(ICategoryService categoryService, IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
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


        [HttpGet]
        public async Task<JsonResult> GetCategoryList()
        {
            var categories = await _categoryService.GetAll();
            return Json(categories);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }



        [HttpPost]
        public async Task<JsonResult> AddProduct([FromBody] ProductModel productModel)
        {
            await _productService.Add(productModel);
            return Json(new { message = "Product added successfully!" });
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
                return Json(new { message = "Category is Deleted" });
            }

            return Json(new { message = "Category isnot  Deleted" });
        }


        [HttpPost]

        public async Task<JsonResult> UploadImage(IFormFile image)
        {
            try
            {

                if (image != null && image.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string uniqeFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqeFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    string imagePath = Path.Combine("/uploads", uniqeFileName);
                    string imageUrl = Url.Content(imagePath);


                    return Json(new { imageUrl });
                }
                return Json(new { error = "Image is not upload" });

            }
            catch (Exception)
            {

                return Json(new { error = "Error Happend" });
            }

        }

        [HttpGet]
        public async Task<JsonResult> GetAllProduct()
        {
            var productList = await _productService.GetAll();
            return Json(productList);
        }
    }
}
