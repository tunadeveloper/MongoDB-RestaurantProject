using MongoDB_RestaurantProject.DataTransferObject.MessageDTOs;

namespace MongoDB_RestaurantProject.Areas.Admin.Models
{
    public class MessageListViewModel
    {
        public List<ResultMessageDTO> InboxMessages { get; set; }
        public List<ResultMessageDTO> SentMessages { get; set; }
        public List<ResultMessageDTO> UnreadMessages { get; set; }
        public List<ResultMessageDTO> FavoriteMessages { get; set; }
    }
}
