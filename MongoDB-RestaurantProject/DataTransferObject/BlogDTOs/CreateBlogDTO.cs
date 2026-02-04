namespace MongoDB_RestaurantProject.DataTransferObject.BlogDTOs
{
    public class CreateBlogDTO
    {
        public string Title { get; set; }
        public string BlogDetails { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Tags { get; set; }
    }

}
