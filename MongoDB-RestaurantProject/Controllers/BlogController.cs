using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.BlogCommentDTOs;
using MongoDB_RestaurantProject.DataTransferObject.BlogDTOs;
using MongoDB_RestaurantProject.Services.BlogCommentService;
using MongoDB_RestaurantProject.Services.BlogService;
using System.Threading.Tasks;
using X.PagedList.Extensions;

namespace MongoDB_RestaurantProject.Controllers
{
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

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 4;
            var list = await _blogService.GetListAsync();
            var result = _mapper.Map<List<ResultBlogDTO>>(list);
            var pagedList = result.ToPagedList(page, pageSize);
            return View(pagedList);
        }

        public async Task<IActionResult> BlogDetails(string id)
        {
            var list = await _blogService.GetByIdAsync(id);
            var result = _mapper.Map<ResultBlogDTO>(list);

            var comments = await _blogCommentService.GetCommentsByBlogIdAsync(id);
            var commentResult = _mapper.Map<List<ResultBlogCommentDTO>>(comments);
            result.Comments = commentResult;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateBlogCommentDTO createBlogCommentDTO)
        {
            createBlogCommentDTO.CreatedAt = DateTime.Now;
            var entity = _mapper.Map<BlogComment>(createBlogCommentDTO);
            await _blogCommentService.CreateAsync(entity);
            return RedirectToAction("BlogDetails", new {id = createBlogCommentDTO.BlogId});
        }
    }
}
