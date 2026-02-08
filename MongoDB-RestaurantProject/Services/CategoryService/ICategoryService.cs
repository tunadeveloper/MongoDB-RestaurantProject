using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Services.GenericService;

namespace MongoDB_RestaurantProject.Services.CategoryService
{
    public interface ICategoryService:IGenericService<Category>
    {
        Task<string> GetCategoryIdByNameAsync(string categoryName);
    }
}
