using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Context.Settings;

namespace MongoDB_RestaurantProject.Services.FeedbackService
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IMongoCollection<Feedback> _mongoCollection;

        public FeedbackService(IMongoDatabase database, IOptions<MongoDbSettings> options)
        {
            _mongoCollection = 
                database.GetCollection<Feedback>(options.Value.FeedbackCollectionName);
        }

        public async Task CreateAsync(Feedback entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x=>x.Id == id);
        }

        public async Task<Feedback> GetByIdAsync(string id)
        {
           return
                await _mongoCollection
                .Find(x=>x.Id==id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Feedback>> GetListAsync()
        {
            return
                await _mongoCollection
                .Find(x=>true)
                .ToListAsync();
        }

        public async Task UpdateAsync(Feedback entity)
        {
           var filter = Builders<Feedback>.Filter.Eq(x=>x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
