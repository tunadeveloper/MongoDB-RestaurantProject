using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.Services.OfferService
{
    public class OfferService : IOfferService
    {
        private readonly IMongoCollection<Offer> _mongoCollection;

        public OfferService(IMongoCollection<Offer> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public async Task CreateAsync(Offer entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<Offer> GetByIdAsync(string id)
        {
            return
                await _mongoCollection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Offer>> GetListAsync()
        {
            return
                await _mongoCollection
                .Find(x => true)
                .ToListAsync();
        }

        public async Task UpdateAsync(Offer entity)
        {
            var filter = Builders<Offer>.Filter.Eq(x => x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
