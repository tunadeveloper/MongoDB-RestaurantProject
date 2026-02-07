using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.GalleryDTOs;
using MongoDB_RestaurantProject.Services.GalleryService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;
        private readonly IMapper _mapper;
        public GalleryController(IGalleryService galleryService, IMapper mapper)
        {
            _galleryService = galleryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _galleryService.GetListAsync();
            var result = _mapper.Map<List<ResultGalleryDTO>>(list);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(CreateGalleryDTO createGalleryDTO)
        {
            var entity = _mapper.Map<Gallery>(createGalleryDTO);
            await _galleryService.CreateAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateImage(UpdateGalleryDTO updateGalleryDTO)
        {
            var entity = _mapper.Map<Gallery>(updateGalleryDTO);
            await _galleryService.UpdateAsync(entity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteImage(string id)
        {
            await _galleryService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
