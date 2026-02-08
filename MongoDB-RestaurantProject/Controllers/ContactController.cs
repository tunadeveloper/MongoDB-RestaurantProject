using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.ContactInfoDTOs;
using MongoDB_RestaurantProject.Services.ContactInfoService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactInfoService _contactInfoService;
        private readonly IMapper _mapper;
        public ContactController(IContactInfoService contactInfoService, IMapper mapper)
        {
            _contactInfoService = contactInfoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _contactInfoService.GetListAsync();
            var result = _mapper.Map<List<ResultContactInfoDTO>>(list).FirstOrDefault();
            return View(result);
        }
    }
}
