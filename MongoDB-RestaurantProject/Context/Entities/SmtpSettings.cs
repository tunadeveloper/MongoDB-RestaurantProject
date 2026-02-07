namespace MongoDB_RestaurantProject.Context.Entities
{
    public class SmtpSettings:BaseEntity
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
