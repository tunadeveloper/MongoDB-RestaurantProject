using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Context.Settings;

namespace MongoDB_RestaurantProject.Services.BlogService
{
    public class BlogService : IBlogService
    {
        private readonly IMongoCollection<Blog> _mongoCollection;

        public BlogService(IMongoDatabase database, IOptions<MongoDbSettings> options)
        {
            _mongoCollection =
                database.GetCollection<Blog>(options.Value.BlogCollectionName);
        }

        public async Task CreateAsync(Blog entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x=>x.Id == id);
        }

        public async Task<Blog> GetByIdAsync(string id)
        {
            return
                await _mongoCollection
                .Find(x=>x.Id ==id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Blog>> GetListAsync()
        {
            return
                await _mongoCollection
                .Find(x=>true)
                .ToListAsync();
        }

        public async Task UpdateAsync(Blog entity)
        {
            var filter =Builders<Blog>.Filter.Eq(x=>x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
