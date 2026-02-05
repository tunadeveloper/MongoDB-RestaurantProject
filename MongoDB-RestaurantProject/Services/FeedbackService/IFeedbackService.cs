using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Services.GenericService;

namespace MongoDB_RestaurantProject.Services.FeedbackService
{
    public interface IFeedbackService:IGenericService<Feedback>
    {
    }
}
