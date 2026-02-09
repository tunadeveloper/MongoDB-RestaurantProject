using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.Services.ProductReviewService
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IMongoCollection<ProductReview> _mongoCollection;

        public ProductReviewService(IMongoCollection<ProductReview> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public async Task CreateAsync(ProductReview entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<ProductReview> GetByIdAsync(string id)
        {
            return
                await _mongoCollection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ProductReview>> GetByProductIdAsync(string id)
        {
            return
                await _mongoCollection
                .Find(x=>x.ProductId == id)
                .ToListAsync();
        }

        public async Task<List<ProductReview>> GetListAsync()
        {
            return
                await _mongoCollection
                .Find(x => true)
                .ToListAsync();
        }

        public async Task UpdateAsync(ProductReview entity)
        {
            var filter = Builders<ProductReview>.Filter.Eq(x => x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
