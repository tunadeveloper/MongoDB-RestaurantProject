using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Services.GenericService;

namespace MongoDB_RestaurantProject.Services.ReservationService
{
    public interface IReservationService:IGenericService<Reservation>
    {
        Task<List<Reservation>> GetAllOrderedAsync();
        Task<List<Reservation>> GetByStatusAsync(bool? status);
    }
}
