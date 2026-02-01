namespace MongoDB_RestaurantProject.Context.Entities
{
    public class Promation:BaseEntity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
