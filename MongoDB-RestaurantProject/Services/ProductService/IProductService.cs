using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Services.GenericService;

namespace MongoDB_RestaurantProject.Services.ProductService
{
    public interface IProductService:IGenericService<Product>
    {
    }
}
