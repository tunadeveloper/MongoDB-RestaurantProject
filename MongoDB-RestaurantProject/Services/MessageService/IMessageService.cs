using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Services.GenericService;

namespace MongoDB_RestaurantProject.Services.MessageService
{
    public interface IMessageService:IGenericService<Message>
    {
    }
}
