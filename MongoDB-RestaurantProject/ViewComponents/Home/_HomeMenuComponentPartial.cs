using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.ProductDTOs;
using MongoDB_RestaurantProject.DataTransferObject.PromationDTOs;
using MongoDB_RestaurantProject.Models;
using MongoDB_RestaurantProject.Services.CategoryService;
using MongoDB_RestaurantProject.Services.ProductService;

namespace MongoDB_RestaurantProject.ViewComponents.Home
{
    public class _HomeMenuComponentPartial : ViewComponent
    {
        private readonly IProductService _productSerivce;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public _HomeMenuComponentPartial(IProductService productSerivce, IMapper mapper, ICategoryService categoryService)
        {
            _productSerivce = productSerivce;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            var mainId = await _categoryService.GetCategoryIdByNameAsync("Ana Yemekler");
            var soupId = await _categoryService.GetCategoryIdByNameAsync("Çorbalar");
            var cucumberId = await _categoryService.GetCategoryIdByNameAsync("Salatalar");
            var dessertId = await _categoryService.GetCategoryIdByNameAsync("Tatlılar");

            var main = await _productSerivce.GetListByCategoryAsync(mainId);
            var soup = await _productSerivce.GetListByCategoryAsync(soupId);
            var cucumber = await _productSerivce.GetListByCategoryAsync(cucumberId);
            var dessert = await _productSerivce.GetListByCategoryAsync(dessertId);

            var model = new HomeMenuViewModel
            {
                Main = _mapper.Map<List<ResultProductDTO>>(main),
                Cucumber = _mapper.Map<List<ResultProductDTO>>(cucumber),
                Dessert = _mapper.Map<List<ResultProductDTO>>(dessert),
                Soup = _mapper.Map<List<ResultProductDTO>>(soup)
            };

            return View(model);
        }
    }
}
