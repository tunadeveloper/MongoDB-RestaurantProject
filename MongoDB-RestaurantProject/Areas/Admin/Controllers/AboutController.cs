using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.AboutDTOs;
using MongoDB_RestaurantProject.Services.AboutService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public async Task<IActionResult> CreateAbout()
        {
           var list = await _aboutService.GetListAsync();
            if (list != null && list.Count > 0)
                return RedirectToAction("UpdateAbout");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDTO createAboutDTO)
        {
            var entity = _mapper.Map<About>(createAboutDTO);
            await _aboutService.CreateAsync(entity);
            return RedirectToAction("UpdateAbout");
        }

        public async Task<IActionResult> UpdateAbout()
        {
            var list = await _aboutService.GetListAsync();
            if (list == null || list.Count == 0)
                return RedirectToAction("CreateAbout");

            var first = list.FirstOrDefault();
            var dto = _mapper.Map<UpdateAboutDTO>(first);
            return View(dto);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            var entity = _mapper.Map<About>(updateAboutDTO);
            await _aboutService.UpdateAsync(entity);
            return RedirectToAction("Index");
        }
    }
}
