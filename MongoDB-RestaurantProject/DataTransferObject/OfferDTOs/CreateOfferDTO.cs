namespace MongoDB_RestaurantProject.DataTransferObject.OfferDTOs
{
    public class CreateOfferDTO
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime RemainingTime { get; set; }
        public string ImageUrl { get; set; }
    }
}
