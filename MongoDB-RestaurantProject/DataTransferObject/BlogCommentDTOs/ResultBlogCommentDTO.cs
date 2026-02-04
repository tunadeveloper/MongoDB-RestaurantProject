namespace MongoDB_RestaurantProject.DataTransferObject.BlogCommentDTOs
{
    public class ResultBlogCommentDTO
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public string BlogId { get; set; }
    }
}
