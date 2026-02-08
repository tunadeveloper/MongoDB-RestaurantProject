using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.OfferDTOs;
using MongoDB_RestaurantProject.Services.OfferService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.ViewComponents.Home
{
    public class _HomeOfferComponentPartial : ViewComponent
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;
        public _HomeOfferComponentPartial(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _offerService.GetListAsync();
            var result = _mapper.Map<List<ResultOfferDTO>>(list);
            var first = result.FirstOrDefault();
            return View(first);
        }
    }
}
