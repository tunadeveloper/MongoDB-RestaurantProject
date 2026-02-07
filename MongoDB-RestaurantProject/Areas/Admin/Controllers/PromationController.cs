using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.PromationDTOs;
using MongoDB_RestaurantProject.Services.PromationService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromationController : Controller
    {
        private readonly IPromationService _promationService;
        private readonly IMapper _mapper;
        public PromationController(IPromationService promationService, IMapper mapper)
        {
            _promationService = promationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _promationService.GetListAsync();
            var result = _mapper.Map<List<ResultPromationDTO>>(list);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromation(CreatePromationDTO createPromationDTO)
        {
            var entity = _mapper.Map<Promation>(createPromationDTO);
            await _promationService.CreateAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePromation(UpdatePromationDTO updatePromationDTO)
        {
            var entity = _mapper.Map<Promation>(updatePromationDTO);
            await _promationService.UpdateAsync(entity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePromation(string id)
        {
            await _promationService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
