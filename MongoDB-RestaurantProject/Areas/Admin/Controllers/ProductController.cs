using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.ProductDTOs;
using MongoDB_RestaurantProject.Services.CategoryService;
using MongoDB_RestaurantProject.Services.ProductService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(string categoryId)
        {
            var list = string.IsNullOrEmpty(categoryId)
                ? await _productService.GetListAsync()
                : await _productService.GetListByCategoryAsync(categoryId);

            var result = _mapper.Map<List<ResultProductDTO>>(list);
            ViewBag.Categories = await _categoryService.GetListAsync();
            ViewBag.SelectedCategory = categoryId;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            var entity = _mapper.Map<Product>(createProductDTO);
            await _productService.CreateAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var entity = _mapper.Map<Product>(updateProductDTO);
            await _productService.UpdateAsync(entity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeCurrentStatus(string id)
        {
            var product = await _productService.GetByIdAsync(id);
            product.IsAvailable = !product.IsAvailable;
            await _productService.UpdateAsync(product);
            return RedirectToAction("Index");
        }
    }
}
