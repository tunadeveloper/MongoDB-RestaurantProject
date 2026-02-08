using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.PromationDTOs;
using MongoDB_RestaurantProject.Services.PromationService;

namespace MongoDB_RestaurantProject.ViewComponents.Home
{
    public class _HomeBannerComponentPartial : ViewComponent
    {
        private readonly IPromationService _promationService;
        private readonly IMapper _mapper;
        public _HomeBannerComponentPartial(IPromationService promationService, IMapper mapper)
        {
            _promationService = promationService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _promationService.GetListAsync();
            var result = _mapper.Map<List<ResultPromationDTO>>(list);
            return View(result);
        }
    }
}
