using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.Services.BlogCommentService
{
    public class BlogCommentService : IBlogCommentService
    {
        private readonly IMongoCollection<BlogComment> _blogComments;

        public BlogCommentService(IMongoCollection<BlogComment> blogComments)
        {
            _blogComments = blogComments;
        }

        public async Task CreateAsync(BlogComment entity)
        {
            await _blogComments.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _blogComments.DeleteOneAsync(x=>x.Id == id);
        }

        public async Task<BlogComment> GetByIdAsync(string id)
        {
            return
                await _blogComments
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<BlogComment>> GetListAsync()
        {
            return
                await _blogComments
                .Find(x=>true)
                .ToListAsync();
        }

        public async Task UpdateAsync(BlogComment entity)
        {
            var filter = Builders<BlogComment>
                .Filter
                .Eq(x => x.Id, entity.Id);
            await _blogComments.ReplaceOneAsync(filter, entity);
        }
    }
}
