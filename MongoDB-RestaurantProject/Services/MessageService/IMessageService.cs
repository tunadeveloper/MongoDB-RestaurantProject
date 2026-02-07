using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Services.GenericService;

namespace MongoDB_RestaurantProject.Services.MessageService
{
    public interface IMessageService:IGenericService<Message>
    {
        Task SendMessageToUserAsync(Message message);

        Task<List<Message>> GetInboxListAsync();
        Task<List<Message>> GetSentListAsync();
        Task<List<Message>> GetUnReadListAsync();
        Task<List<Message>> GetFavoriteListAsync();
    }
}
