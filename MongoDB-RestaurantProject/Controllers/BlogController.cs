using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.BlogDTOs;
using MongoDB_RestaurantProject.Services.BlogService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _blogService.GetListAsync();
            var result = _mapper.Map<List<ResultBlogDTO>>(list);
            return View(result);
        }
    }
}
