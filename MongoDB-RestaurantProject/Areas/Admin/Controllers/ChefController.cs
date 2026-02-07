using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.ChefDTOs;
using MongoDB_RestaurantProject.Services.ChefService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        [HttpPost]
        public async Task<IActionResult> CreateChef(CreateChefDTO createChefDTO)
        {
            var entity = _mapper.Map<Chef>(createChefDTO);
            await _chefService.CreateAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateChef(UpdateChefDTO updateChefDTO)
        {
            var enity = _mapper.Map<Chef>(updateChefDTO);
            await _chefService.UpdateAsync(enity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteChef(string id)
        {
            await _chefService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
