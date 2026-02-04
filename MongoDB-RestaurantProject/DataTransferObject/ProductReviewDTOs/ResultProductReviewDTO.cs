namespace MongoDB_RestaurantProject.DataTransferObject.ProductReviewDTOs
{
    public class ResultProductReviewDTO
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int Star { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
