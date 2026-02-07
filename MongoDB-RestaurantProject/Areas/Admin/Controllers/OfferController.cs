using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.OfferDTOs;
using MongoDB_RestaurantProject.Services.OfferService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;
        public OfferController(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _offerService.GetListAsync();
            var result = _mapper.Map<List<ResultOfferDTO>>(list);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateOfferDTO createOfferDTO)
        {
            var entity = _mapper.Map<Offer>(createOfferDTO);
            await _offerService.CreateAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOffer(UpdateOfferDTO updateOfferDTO)
        {
            var entity = _mapper.Map<Offer>(updateOfferDTO);
            await _offerService.UpdateAsync(entity);
            return RedirectToAction("Index");
        }
    }
}
