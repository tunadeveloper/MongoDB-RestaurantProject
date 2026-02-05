using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.Services.GalleryService
{
    public class GalleryService : IGalleryService
    {
        private readonly IMongoCollection<Gallery> _mongoCollection;

        public GalleryService(IMongoCollection<Gallery> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public async Task CreateAsync(Gallery entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x=>x.Id == id);
        }

        public async Task<Gallery> GetByIdAsync(string id)
        {
            return
                await _mongoCollection
                .Find(x=>x.Id ==id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Gallery>> GetListAsync()
        {
            return
                await _mongoCollection
                .Find(x => true)
                .ToListAsync();
        }

        public async Task UpdateAsync(Gallery entity)
        {
            var filter = Builders<Gallery>.Filter.Eq(x=>x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
