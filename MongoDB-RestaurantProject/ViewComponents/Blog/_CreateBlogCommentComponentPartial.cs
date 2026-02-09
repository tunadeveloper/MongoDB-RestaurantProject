using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.BlogCommentDTOs;

namespace MongoDB_RestaurantProject.ViewComponents.Blog
{
    public class _CreateBlogCommentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke(CreateBlogCommentDTO dTO)
        {
            return View(dTO);
        }
    }
}
