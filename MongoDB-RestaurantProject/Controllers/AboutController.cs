using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.AboutDTOs;
using MongoDB_RestaurantProject.Services.AboutService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _aboutService.GetListAsync();
            var result = _mapper.Map<List<ResultAboutDTO>>(list).FirstOrDefault();
            return View(result);
        }
    }
}
