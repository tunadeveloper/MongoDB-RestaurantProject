using MongoDB_RestaurantProject.DataTransferObject.ReservationDTOs;

namespace MongoDB_RestaurantProject.Areas.Admin.Models
{
    public class ReservationListViewModel
    {
        public List<ResultReservationDTO> AllReservations { get; set; }
        public List<ResultReservationDTO> PendingReservations { get; set; }
        public List<ResultReservationDTO> ApprovedReservations { get; set; }
        public List<ResultReservationDTO> CancelledReservations { get; set; }
    }
}
