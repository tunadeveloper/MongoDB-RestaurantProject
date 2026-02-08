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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryNames = new List<string> { "Ana Yemekler", "Çorbalar", "Salatalar", "Tatlılar" };
            var model = new List<MenuCategoryViewModel>();

            foreach(var item in categoryNames)
            {
                var categoryId = await _categoryService.GetCategoryIdByNameAsync(item);
                if (!string.IsNullOrEmpty(categoryId))
                {
                    var products = await _productSerivce.GetListByCategoryAsync(categoryId);
                    model.Add(new MenuCategoryViewModel
                    {
                        CategoryName = item,
                        Products = _mapper.Map<List<ResultProductDTO>>(products.Take(4))
                    });
                }
            }

            return View(model);
        }
    }
}
