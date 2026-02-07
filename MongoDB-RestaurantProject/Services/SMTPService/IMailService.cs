using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Services.GenericService;

namespace MongoDB_RestaurantProject.Services.SMTPService
{
    public interface IMailService:IGenericService<SmtpSettings>
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
