using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Context.Settings;

namespace MongoDB_RestaurantProject.Services.ChefService
{
    public class ChefService : IChefService
    {
        private readonly IMongoCollection<Chef> _mongoCollection;

        public ChefService(IMongoDatabase database, IOptions<MongoDbSettings> options)
        {
            _mongoCollection =
                database.GetCollection<Chef>(options.Value.ChefCollectionName);
        }

        public async Task CreateAsync(Chef entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x=>x.Id == id);
        }

        public async Task<Chef> GetByIdAsync(string id)
        {
            return
                await _mongoCollection
                .Find(x=>x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Chef>> GetListAsync()
        {
            return
                await _mongoCollection
                .Find(x=>true)
                .ToListAsync();
        }

        public async Task UpdateAsync(Chef entity)
        {
            var filter = Builders<Chef>.Filter.Eq(x=>x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
