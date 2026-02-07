namespace MongoDB_RestaurantProject.Services.SMTPService
{
    public interface IMailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
