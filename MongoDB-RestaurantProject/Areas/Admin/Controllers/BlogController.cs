using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.BlogCommentDTOs;
using MongoDB_RestaurantProject.DataTransferObject.BlogDTOs;
using MongoDB_RestaurantProject.Services.BlogCommentService;
using MongoDB_RestaurantProject.Services.BlogService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBlogCommentService _blogCommentService;
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, IMapper mapper, IBlogCommentService blogCommentService)
        {
            _blogService = blogService;
            _mapper = mapper;
            _blogCommentService = blogCommentService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetListAsync();
            var blogDtos = _mapper.Map<List<ResultBlogDTO>>(blogs);

            foreach (var blog in blogDtos)
            {
                var comments = await _blogCommentService.GetCommentsByBlogIdAsync(blog.Id);
                blog.Comments = _mapper.Map<List<ResultBlogCommentDTO>>(comments);
            }

            return View(blogDtos);
        }

        public async Task<IActionResult> DeleteBlog(string id)
        {
            await _blogService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDTO dto)
        {
            dto.CreatedAt = DateTime.Now;
            var entity = _mapper.Map<Blog>(dto);
            await _blogService.CreateAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDTO dto)
        {
            var entity = _mapper.Map<Blog>(dto);
            await _blogService.UpdateAsync(entity);
            return RedirectToAction("Index");
        }
    }
}
