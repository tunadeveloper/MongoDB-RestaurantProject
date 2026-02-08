using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.ProductDTOs;
using MongoDB_RestaurantProject.Services.ProductService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.ViewComponents.Home
{
    public class _HomeProductComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public _HomeProductComponentPartial(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _productService.GetListPopularAndInStockProductAsync();
            var result = _mapper.Map<List<ResultProductDTO>>(list);
            return View(result);
        }
    }
}
