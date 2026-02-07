using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.ProductReviewDTOs;
using MongoDB_RestaurantProject.Services.ProductReviewService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductReviewController : Controller
    {
        private readonly IProductReviewService _productReviewService;
        private readonly IMapper _mapper;
        public ProductReviewController(IProductReviewService productReviewService, IMapper mapper)
        {
            _productReviewService = productReviewService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string id)
        {
            var list = await _productReviewService.GetByIdAsync(id);
            var result = _mapper.Map<List<ResultProductReviewDTO>>(list);
            return View(result);
        }

        public async Task<IActionResult> DeleteReview(string id)
        {
            await _productReviewService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
