using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.FeedbackDTOs;
using MongoDB_RestaurantProject.Services.FeedbackService;

namespace MongoDB_RestaurantProject.ViewComponents.Home
{
    public class _HomeFeedbackComponentPartial : ViewComponent
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;
        public _HomeFeedbackComponentPartial(IFeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _feedbackService.GetListAsync();
            var result = _mapper.Map<List<ResultFeedbackDTO>>(list);
            return View(result);
        }
    }
}
