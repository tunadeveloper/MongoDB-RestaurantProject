using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.BlogDTOs;
using MongoDB_RestaurantProject.Services.BlogService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.ViewComponents.Home
{
    public class _HomeBlogComponentPartial : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public _HomeBlogComponentPartial(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _blogService.GetListAsync();
            var result = _mapper.Map<List<ResultBlogDTO>>(list);
            return View(result);
        }
    }
}
