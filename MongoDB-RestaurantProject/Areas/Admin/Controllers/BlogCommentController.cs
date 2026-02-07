using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.BlogCommentDTOs;
using MongoDB_RestaurantProject.Services.BlogCommentService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogCommentController : Controller
    {
        private readonly IBlogCommentService _blogCommentService;
        private readonly IMapper _mapper;
        public BlogCommentController(IBlogCommentService blogCommentService, IMapper mapper)
        {
            _blogCommentService = blogCommentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetCommentsByBlog(string id)
        {
            var list = await _blogCommentService.GetCommentsByBlogIdAsync(id);
            var result = _mapper.Map<List<ResultBlogCommentDTO>>(list);
            return Json(result);
        }

        public async Task<IActionResult> DeleteBlogComment(string id)
        {
            await _blogCommentService.DeleteAsync(id);
            return Json(new { success = true });
        }

        public IActionResult CreateBlogComment() => View();
        [HttpPost]
        public async Task<IActionResult> CreateBlogComment(CreateBlogCommentDTO createBlogCommentDTO)
        {
            createBlogCommentDTO.CreatedAt = DateTime.Now;
            var entity = _mapper.Map<BlogComment>(createBlogCommentDTO);
            await _blogCommentService.CreateAsync(entity);
            return Redirect("/Admin/Blog/Index");
        }
    }
}
