using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.Services.ContactInfoService
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IMongoCollection<ContactInfo> _mongoCollection;

        public ContactInfoService(IMongoCollection<ContactInfo> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public async Task CreateAsync(ContactInfo entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<ContactInfo> GetByIdAsync(string id)
        {
            return
                await _mongoCollection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ContactInfo>> GetListAsync()
        {
            return
                await _mongoCollection
                .Find(x => true)
                .ToListAsync();
        }

        public async Task UpdateAsync(ContactInfo entity)
        {
            var filter = Builders<ContactInfo>.Filter.Eq(x => x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
