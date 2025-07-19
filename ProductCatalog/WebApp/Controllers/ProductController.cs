namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController:Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService; //

        public ProductController(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories,"Id","Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if(!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllAsync();
                ViewBag.Categories = new SelectList(categories,"Id","Name");
                return View(model);
            }

            //await _productService.CreateProductAsync(model); //

            return RedirectToAction("Index");
        }
    }
}
