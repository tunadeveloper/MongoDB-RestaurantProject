using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Context.Settings;

namespace MongoDB_RestaurantProject.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IMongoCollection<Admin> _mongoCollection;

        public AdminService(IMongoDatabase database, IOptions<MongoDbSettings> options)
        {
            _mongoCollection =
                database.GetCollection<Admin>(options.Value.AdminCollectionName);
        }

        public async Task CreateAsync(Admin entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x=>x.Id == id);
        }

        public async Task<Admin> GetByIdAsync(string id)
        {
            return
                await _mongoCollection
                .Find(x=>x.Id==id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Admin>> GetListAsync()
        {
            return
                await _mongoCollection
                .Find(x => true)
                .ToListAsync();
        }

        public async Task<Admin> LoginAsync(string email, string password)
        {
            var admin = await _mongoCollection
                .Find(x=>x.Email==email && x.Password==password)
                .FirstOrDefaultAsync();

            if (admin == null)
                return null;
            if (admin.Password != password)
                return null;

            return admin;
        }

        public async Task UpdateAsync(Admin entity)
        {
           var filter = Builders<Admin>.Filter.Eq(x=>x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
