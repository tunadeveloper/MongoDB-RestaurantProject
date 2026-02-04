using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_RestaurantProject.Context.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Weight { get; set; }
        public string Dimensions { get; set; }
        public float PriceHalf { get; set; }
        public float PriceFull { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsPopular { get; set; }
        public List<string> Ingredients { get; set; }



        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        public List<ProductReview> Reviews { get; set; }
    }
}
