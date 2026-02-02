namespace MongoDB_RestaurantProject.Context.Entities
{
    public class Reservation:BaseEntity
    {
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string NumberOfPeople { get; set; }
        public DateTime ReservationAt { get; set; }
        public bool? Status { get; set; }
    }
}
