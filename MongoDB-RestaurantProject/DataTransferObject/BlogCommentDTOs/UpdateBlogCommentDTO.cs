namespace MongoDB_RestaurantProject.DataTransferObject.BlogCommentDTOs
{
    public class UpdateBlogCommentDTO
    {
        public string Id { get; set; }
        public string BlogId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
