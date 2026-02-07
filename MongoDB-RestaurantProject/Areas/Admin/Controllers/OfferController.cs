using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.OfferDTOs;
using MongoDB_RestaurantProject.Services.OfferService;

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

        [HttpGet]
        public async Task<IActionResult> CreateOffer()
        {
            var list = await _offerService.GetListAsync();
            if (list != null && list.Count > 0)
                return RedirectToAction("UpdateOffer");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateOfferDTO createOfferDTO)
        {
            var entity = _mapper.Map<Offer>(createOfferDTO);
            await _offerService.CreateAsync(entity);
            return RedirectToAction("UpdateOffer");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateOffer()
        {
            var list = await _offerService.GetListAsync();
            if (list == null || list.Count == 0)
                return RedirectToAction("CreateOffer");
            var first = list.FirstOrDefault();
            var entity = _mapper.Map<UpdateOfferDTO>(first);
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOffer(UpdateOfferDTO updateOfferDTO)
        {
            var entity = _mapper.Map<Offer>(updateOfferDTO);
            await _offerService.UpdateAsync(entity);
            return RedirectToAction("UpdateOffer");
        }

        public async Task<IActionResult> DeleteOffer(string id)
        {
            await _offerService.DeleteAsync(id);
            return RedirectToAction("CreateOffer");
        }
    }
}
