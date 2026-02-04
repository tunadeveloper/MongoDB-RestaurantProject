namespace MongoDB_RestaurantProject.DataTransferObject.BlogCommentDTOs
{
    public class CreateBlogCommentDTO
    {
        public string BlogId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
    }
}
