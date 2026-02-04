namespace MongoDB_RestaurantProject.DataTransferObject.AdminDTOs
{
    public class UpdateAdminDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
    }
}
