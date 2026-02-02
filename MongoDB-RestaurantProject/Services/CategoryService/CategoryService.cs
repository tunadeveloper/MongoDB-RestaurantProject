using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Context.Settings;
using MongoDB_RestaurantProject.Services.CategoryService;

namespace MongoDB_RestaurantProject.Services.GenericService
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _mongoCollection;

        public CategoryService(IMongoDatabase database, IOptions<MongoDbSettings> options)
        {
            _mongoCollection =
                database.GetCollection<Category>(options.Value.CategoryCollectionName);
        }

        public async Task CreateAsync(Category entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<Category> GetByIdAsync(string id)
        {
            return await _mongoCollection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Category>> GetListAsync()
        {
            return await _mongoCollection
                 .Find(x => true)
                 .ToListAsync();
        }

        public async Task UpdateAsync(Category entity)
        {
            var filter = Builders<Category>.Filter.Eq(x => x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
