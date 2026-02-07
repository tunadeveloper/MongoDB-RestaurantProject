
using MongoDB_RestaurantProject.Context.Entities;
using System.Net;
using System.Net.Mail;

namespace MongoDB_RestaurantProject.Services.SMTPService
{
    public class MailService : IMailService
    {
        private readonly SmtpSettings _settings;

        public MailService(SmtpSettings settings)
        {
            _settings = settings;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_settings.UserName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mail.To.Add(to);

            using var smtp = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.UserName, _settings.Password),
                EnableSsl = _settings.EnableSsl
            };

            await smtp.SendMailAsync(mail);
        }
    }
}
