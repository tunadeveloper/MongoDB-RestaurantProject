using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Services.GalleryService;

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

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
