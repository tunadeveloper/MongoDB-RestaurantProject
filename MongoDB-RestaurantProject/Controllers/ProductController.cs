using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.CategoryDTOs;
using MongoDB_RestaurantProject.DataTransferObject.ProductDTOs;
using MongoDB_RestaurantProject.Models;
using MongoDB_RestaurantProject.Services.CategoryService;
using MongoDB_RestaurantProject.Services.ProductService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await _productService.GetListAsync();
            var allCategories = await _categoryService.GetListAsync();

            var productDtos = _mapper.Map<List<ResultProductDTO>>(allProducts);

            foreach (var productDto in productDtos)
            {
                var category = await _categoryService.GetByIdAsync(productDto.CategoryId);
                if (category != null)
                {
                    productDto.CategoryName = category.CategoryName;
                }
            }

            var model = new MenuIndexViewModel
            {
                Products = productDtos,
                Categories = _mapper.Map<List<ResultCategoryDTO>>(allCategories)
            };

            return View(model);
        }

        public async Task<IActionResult> ProductDetail(string id)
        {
            var list = await _productService.GetByIdAsync(id);
            var result = _mapper.Map<List<ResultProductDTO>>(list);
            return View(result);
        }
    }
}
