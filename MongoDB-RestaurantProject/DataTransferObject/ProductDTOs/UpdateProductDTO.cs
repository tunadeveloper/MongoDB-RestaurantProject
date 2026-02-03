namespace MongoDB_RestaurantProject.DataTransferObject.ProductDTOs
{
    public class UpdateProductDTO
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Weight { get; set; }
        public string Dimensions { get; set; }
        public float PriceHalf { get; set; }
        public float PriceFull { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsPopular { get; set; }
        public List<string> Ingredients { get; set; }

        public string CategoryId { get; set; }
    }
}
