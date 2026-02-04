namespace MongoDB_RestaurantProject.DataTransferObject.ReservationDTOs
{
    public class UpdateResevationDTO
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string NumberOfPeople { get; set; }
        public DateTime ReservationAt { get; set; }
        public bool? Status { get; set; }
    }
}
