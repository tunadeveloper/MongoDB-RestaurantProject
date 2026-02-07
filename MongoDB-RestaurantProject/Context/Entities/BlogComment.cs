namespace MongoDB_RestaurantProject.Context.Entities
{
    public class BlogComment:BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string BlogId { get; set; }

    }
}
