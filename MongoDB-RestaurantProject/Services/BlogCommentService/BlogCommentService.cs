using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Context.Settings;

namespace MongoDB_RestaurantProject.Services.BlogCommentService
{
    public class BlogCommentService : IBlogCommentService
    {
        private readonly IMongoCollection<BlogComment> _blogComments;

        public BlogCommentService(IMongoDatabase database, IOptions<MongoDbSettings> options)
        {
            _blogComments =
                database.GetCollection<BlogComment>(options.Value.BlogCommentCollectionName);
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

        public async Task<List<BlogComment>> GetCommentsByBlogIdAsync(string blogId)
        {
            return
                await _blogComments
                .Find(x=>x.BlogId ==blogId)
                .ToListAsync();
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
