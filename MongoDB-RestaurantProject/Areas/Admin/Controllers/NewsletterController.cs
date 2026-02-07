using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.NewsletterDTOs;
using MongoDB_RestaurantProject.Services.NewsletterService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsletterController : Controller
    {
        private readonly INewsletterSerivce _newsletterService;
        private readonly IMapper _mapper;
        public NewsletterController(INewsletterSerivce newsletterService, IMapper mapper)
        {
            _newsletterService = newsletterService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _newsletterService.GetListAsync();
            var result = _mapper.Map<List<ResultNewsletterDTO>>(list);
            return View(result);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            await _newsletterService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
