using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.ChefDTOs;
using MongoDB_RestaurantProject.Services.ChefService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.ViewComponents.Home
{
    public class _HomeChefComponentPartial : ViewComponent
    {
        private readonly IChefService _chefService;
        private readonly IMapper _mapper;
        public _HomeChefComponentPartial(IChefService chefService, IMapper mapper)
        {
            _chefService = chefService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _chefService.GetListAsync();
            var result = _mapper.Map<List<ResultChefDTO>>(list);
            return View(result);
        }
    }
}
