namespace MongoDB_RestaurantProject.Context.Entities
{
    public class Message:BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserMessage { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsFavorite { get; set; }
        public string UserOrAdmin { get; set; }
    }
}
