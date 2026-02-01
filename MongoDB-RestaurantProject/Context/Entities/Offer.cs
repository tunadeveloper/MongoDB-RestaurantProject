namespace MongoDB_RestaurantProject.Context.Entities
{
    public class Offer:BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime RemainingTime { get; set; }
        public string ImageUrl { get; set; }
    }
}
