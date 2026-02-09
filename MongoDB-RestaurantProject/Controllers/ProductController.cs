using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.CategoryDTOs;
using MongoDB_RestaurantProject.DataTransferObject.ProductDTOs;
using MongoDB_RestaurantProject.DataTransferObject.ProductReviewDTOs;
using MongoDB_RestaurantProject.Models;
using MongoDB_RestaurantProject.Services.CategoryService;
using MongoDB_RestaurantProject.Services.ProductReviewService;
using MongoDB_RestaurantProject.Services.ProductService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IProductReviewService _productReviewService;
        public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService, IProductReviewService productReviewService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
            _productReviewService = productReviewService;
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
            var product = await _productService.GetByIdAsync(id);
            var result = _mapper.Map<ResultProductDTO>(product);
            var category = await _categoryService.GetByIdAsync(result.CategoryId);

            if (category != null)
            {
                result.CategoryName = category.CategoryName;
            }
            var reviews = await _productReviewService.GetByProductIdAsync(id);
            result.Reviews = reviews;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateProductReviewDTO createProductReviewDTO)
        {
            createProductReviewDTO.CreatedAt = DateTime.Now;
            var entity = _mapper.Map<ProductReview>(createProductReviewDTO);
            await _productReviewService.CreateAsync(entity);
            return RedirectToAction("ProductDetail", new { id = createProductReviewDTO.ProductId });

        }
    }
}
