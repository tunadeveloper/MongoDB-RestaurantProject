namespace MongoDB_RestaurantProject.Context.Entities
{
    public class ProductReview:BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int Star { get; set; }
        public DateTime CreatedAt { get; set; }

        public string ProductId { get; set; }
    }
}
