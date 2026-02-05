using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Services.GenericService;

namespace MongoDB_RestaurantProject.Services.ReservationService
{
    public interface IReservationService:IGenericService<Reservation>
    {
    }
}
