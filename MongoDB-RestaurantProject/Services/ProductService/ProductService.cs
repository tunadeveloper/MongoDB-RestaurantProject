using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Context.Settings;
using MongoDB_RestaurantProject.DataTransferObject.ProductDTOs;
using MongoDB_RestaurantProject.Models;

namespace MongoDB_RestaurantProject.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _mongoCollection;

        public ProductService(IMongoDatabase database, IOptions<MongoDbSettings> options)
        {
            _mongoCollection =
                 database.GetCollection<Product>(options.Value.ProductCollectionName);
        }

        public async Task CreateAsync(Product entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _mongoCollection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetListAsync()
        {
            return await _mongoCollection
                .Find(x => true)
                .ToListAsync();
        }

        public async Task<List<Product>> GetListByCategoryAsync(string categoryId)
        {
            return await _mongoCollection
                .Find(x=>x.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<List<Product>> GetListPopularAndInStockProductAsync()
        {
            return
               await _mongoCollection
               .Find(x=>x.IsPopular == true && x.IsAvailable == true)
               .ToListAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
