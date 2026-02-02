namespace MongoDB_RestaurantProject.Context.Entities
{
    public class ContactInfo:BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string email { get; set; }
        public string MapUrl { get; set; }
    }
}
