using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.ChefDTOs;
using MongoDB_RestaurantProject.Services.ChefService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Controllers
{
    [AllowAnonymous]
    public class ChefController : Controller
    {
        private readonly IChefService _chefService;
        private readonly IMapper _mapper;
        public ChefController(IChefService chefService, IMapper mapper)
        {
            _chefService = chefService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _chefService.GetListAsync();
            var result = _mapper.Map<List<ResultChefDTO>>(list);
            return View(result);
        }

        public async Task<IActionResult> ChefDetails(string id)
        {
            var list = await _chefService.GetByIdAsync(id);
            var result = _mapper.Map<ResultChefDTO>(list);
            return View(result);
        }
    }
}
