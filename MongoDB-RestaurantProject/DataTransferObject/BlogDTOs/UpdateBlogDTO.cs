namespace MongoDB_RestaurantProject.DataTransferObject.BlogDTOs
{
    public class UpdateBlogDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string BlogDetails { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Tags { get; set; }
    }
}
