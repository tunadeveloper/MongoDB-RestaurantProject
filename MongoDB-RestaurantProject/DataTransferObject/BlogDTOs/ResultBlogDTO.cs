using MongoDB_RestaurantProject.DataTransferObject.BlogCommentDTOs;

namespace MongoDB_RestaurantProject.DataTransferObject.BlogDTOs
{
    public class ResultBlogDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string BlogDetails { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Tags { get; set; }

        public List<ResultBlogCommentDTO> Comments { get; set; }
    }
}
