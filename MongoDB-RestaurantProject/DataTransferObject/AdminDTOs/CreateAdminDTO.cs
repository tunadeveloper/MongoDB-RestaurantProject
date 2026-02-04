namespace MongoDB_RestaurantProject.DataTransferObject.AdminDTOs
{
    public class CreateAdminDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
    }
}
