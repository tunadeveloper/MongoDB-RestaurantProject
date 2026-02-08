using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.NewsletterDTOs;
using MongoDB_RestaurantProject.Services.NewsletterService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly INewsletterSerivce _newsletterService;
        private readonly IMapper _mapper;
        public NewsletterController(INewsletterSerivce newsletterService, IMapper mapper)
        {
            _newsletterService = newsletterService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateNewsletterDTO createNewsletterDTO)
        {
            var entity = _mapper.Map<Newsletter>(createNewsletterDTO);
            await _newsletterService.CreateAsync(entity);
            return RedirectToAction("Index", "Home");
        }
    }
}
