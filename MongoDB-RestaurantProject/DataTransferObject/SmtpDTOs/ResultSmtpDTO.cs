namespace MongoDB_RestaurantProject.DataTransferObject.SmtpDTOs
{
    public class ResultSmtpDTO
    {
        public string Id { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
