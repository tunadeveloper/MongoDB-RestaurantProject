namespace MongoDB_RestaurantProject.Context.Entities
{
    public class Chef:BaseEntity
    {
        public string NameSurname { get; set; }
        public string PositionName { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedInUrl { get; set; }
    }
}
