using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.Services.AboutService
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _mongoCollection;

        public AboutService(IMongoCollection<About> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public async Task CreateAsync(About entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x=>x.Id == id);
        }

        public async Task<About> GetByIdAsync(string id)
        {
            return
                await _mongoCollection
                .Find(x=>x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<About>> GetListAsync()
        {
           return
                await _mongoCollection
                .Find(x=>true)
                .ToListAsync();
        }

        public async Task UpdateAsync(About entity)
        {
            var filter = Builders<About>.Filter.Eq(x=>x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
