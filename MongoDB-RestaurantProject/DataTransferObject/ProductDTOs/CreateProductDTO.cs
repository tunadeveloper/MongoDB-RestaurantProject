using MongoDB_RestaurantProject.Context.Entities;

namespace MongoDB_RestaurantProject.DataTransferObject.ProductDTOs
{
    public class CreateProductDTO

    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Weight { get; set; }
        public string Dimensions { get; set; }
        public float PriceHalf { get; set; }
        public float PriceFull { get; set; }
        public bool IsAvailable { get; set; } = true;
        public bool IsPopular { get; set; }
        public List<string> Ingredients { get; set; }

        public string CategoryId { get; set; }
    }
}
