using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.GalleryDTOs;
using MongoDB_RestaurantProject.Services.GalleryService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.ViewComponents.Home
{
    public class _HomeGalleryComponentPartial : ViewComponent
    {
        private readonly IGalleryService _galleryService;
        private readonly IMapper _mapper;
        public _HomeGalleryComponentPartial(IGalleryService galleryService, IMapper mapper)
        {
            _galleryService = galleryService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _galleryService.GetListAsync();
            var result = _mapper.Map<List<ResultGalleryDTO>>(list);
            return View(result);
        }
    }
}
