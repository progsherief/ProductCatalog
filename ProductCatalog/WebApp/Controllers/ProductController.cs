using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Core.Contracts;
using Shared.ViewModels.Product;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController:Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProductService productService,IWebHostEnvironment environment)
        {
            _productService = productService;
            _environment = environment;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            // ✅ Validate and save image
            if(model.ImageFile != null)
            {
                if(!FileHelper.ValidateImage(model.ImageFile,out var error))
                {
                    ModelState.AddModelError("ImageFile",error);
                    return View(model);
                }

                var imageName = $"{Guid.NewGuid()}{Path.GetExtension(model.ImageFile.FileName)}";
                var imagePath = Path.Combine(_environment.WebRootPath,"images",imageName);

                using var stream = new FileStream(imagePath,FileMode.Create);
                await model.ImageFile.CopyToAsync(stream);

                model.ImagePath = $"/images/{imageName}";
            }

            var userId = User.Identity?.Name ?? "System";
            await _productService.AddProductAsync(model,userId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var products = await _productService.GetAllAsync();
            var product = products.FirstOrDefault(p => p.Id == id);
            if(product == null)
                return NotFound();

            var model = new ProductEditViewModel
            {
                Id = product.Id,
                Name = product.Name,
                StartDate = product.StartDate,
                DurationInDays = product.DurationInDays,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ImagePath = product.ImagePath
            };

            return View(model);
        }

        // POST: Product/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);
            if(model.ImageFile != null)
            {
                if(!FileHelper.ValidateImage(model.ImageFile,out var error))
                {
                    ModelState.AddModelError("ImageFile",error);
                    return View(model);
                }

                var imageName = $"{Guid.NewGuid()}{Path.GetExtension(model.ImageFile.FileName)}";
                var imagePath = Path.Combine(_environment.WebRootPath,"images",imageName);

                using var stream = new FileStream(imagePath,FileMode.Create);
                await model.ImageFile.CopyToAsync(stream);

                model.ImagePath = $"/images/{imageName}";
            }

            var userId = User.Identity?.Name ?? "System";
            await _productService.EditProductAsync(model,userId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
     
    }
}
