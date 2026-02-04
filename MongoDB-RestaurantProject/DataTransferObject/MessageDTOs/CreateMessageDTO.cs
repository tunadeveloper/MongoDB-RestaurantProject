namespace MongoDB_RestaurantProject.DataTransferObject.MessageDTOs
{
    public class CreateMessageDTO
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserMessage { get; set; }
    }
}
