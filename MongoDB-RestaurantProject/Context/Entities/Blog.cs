using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_RestaurantProject.Context.Entities
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; }
        public string BlogDetails { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Tags { get; set; }
    }
}
