using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Services.BlogCommentService;
using MongoDB_RestaurantProject.Services.BlogService;
using MongoDB_RestaurantProject.Services.MessageService;
using MongoDB_RestaurantProject.Services.ProductReviewService;
using MongoDB_RestaurantProject.Services.ProductService;
using MongoDB_RestaurantProject.Services.ReservationService;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IBlogService _blogservice;
        private readonly IReservationService _reservationService;
        private readonly IMessageService _messageService;
        private readonly IProductReviewService _productReviewService;
        private readonly IBlogCommentService _blogCommentService;
        private readonly IProductService _productService;

        public DashboardController(IBlogService blogservice, IReservationService reservationService, IMessageService messageService, IProductReviewService productReviewService, IBlogCommentService blogCommentService, IProductService productService)
        {
            _blogservice = blogservice;
            _reservationService = reservationService;
            _messageService = messageService;
            _productReviewService = productReviewService;
            _blogCommentService = blogCommentService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetListAsync();
            ViewBag.TotalProducts = products.Count;
            ViewBag.AvgPrice = products.Any() ? products.Average(x => x.PriceFull).ToString("0.00") : "0";

            var reservations = await _reservationService.GetListAsync();
            ViewBag.TotalReservations = reservations.Count;
            ViewBag.PendingReservations = reservations.Where(x => x.Status == null).Count();
            ViewBag.ApprovedReservations = reservations.Where(x => x.Status == true).Count();

            var messages = await _messageService.GetListAsync();
            ViewBag.TotalMessages = messages.Count;
            ViewBag.UnreadMessages = messages.Where(x => x.IsRead == false).Count();

            var blogs = await _blogservice.GetListAsync();
            var comments = await _blogCommentService.GetListAsync();
            ViewBag.TotalBlogs = blogs.Count;
            ViewBag.TotalComments = comments.Count;

            var reviews = await _productReviewService.GetListAsync();
            ViewBag.TotalReviews = reviews.Count;
            ViewBag.AvgRating = reviews.Any() ? reviews.Average(x => x.Star).ToString("0.0") : "0.0";

            return View();
        }
    }
}