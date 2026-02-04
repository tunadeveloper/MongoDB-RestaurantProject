namespace MongoDB_RestaurantProject.DataTransferObject.OfferDTOs
{
    public class UpdateOfferDTO
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime RemainingTime { get; set; }
        public string ImageUrl { get; set; }
    }
}
