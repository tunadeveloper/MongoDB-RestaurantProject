using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.FeedbackDTOs;
using MongoDB_RestaurantProject.Services.FeedbackService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;
        public FeedbackController(IFeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _feedbackService.GetListAsync();
            var result = _mapper.Map<List<ResultFeedbackDTO>>(list);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedback(CreateFeedbackDTO createFeedbackDTO)
        {
            var entity = _mapper.Map<Feedback>(createFeedbackDTO);
            await _feedbackService.CreateAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeedback(UpdateFeedbackDTO updateFeedbackDTO)
        {
            var entity = _mapper.Map<Feedback>(updateFeedbackDTO);
            await _feedbackService.UpdateAsync(entity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeedback(string id)
        {
            await _feedbackService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
