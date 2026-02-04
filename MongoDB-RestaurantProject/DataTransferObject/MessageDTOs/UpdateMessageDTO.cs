namespace MongoDB_RestaurantProject.DataTransferObject.MessageDTOs
{
    public class UpdateMessageDTO
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserMessage { get; set; }
    }
}
