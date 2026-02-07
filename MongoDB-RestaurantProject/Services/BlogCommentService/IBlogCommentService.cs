using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Services.GenericService;

namespace MongoDB_RestaurantProject.Services.BlogCommentService
{
    public interface IBlogCommentService:IGenericService<BlogComment>
    {
        Task<List<BlogComment>> GetCommentsByBlogIdAsync(string blogId);
    }
}
