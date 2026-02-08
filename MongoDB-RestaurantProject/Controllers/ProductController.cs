using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.ProductDTOs;
using MongoDB_RestaurantProject.Services.ProductService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _productService.GetListAsync();
            var result = _mapper.Map<List<ResultProductDTO>>(list);
            return View(result);
        }

        public async Task<IActionResult> ProductDetail(string id)
        {
            var list = await _productService.GetByIdAsync(id);
            var result = _mapper.Map<List<ResultProductDTO>>(list);
            return View(result);
        }
    }
}
