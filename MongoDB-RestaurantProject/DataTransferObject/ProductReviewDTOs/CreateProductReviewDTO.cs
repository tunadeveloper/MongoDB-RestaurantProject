namespace MongoDB_RestaurantProject.DataTransferObject.ProductReviewDTOs
{
    public class CreateProductReviewDTO
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int Star { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ProductId { get; set; }
    }
}
