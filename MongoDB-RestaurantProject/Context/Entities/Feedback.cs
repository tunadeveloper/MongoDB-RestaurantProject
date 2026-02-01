namespace MongoDB_RestaurantProject.Context.Entities
{
    public class Feedback:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrl2 { get; set; }
    }
}
