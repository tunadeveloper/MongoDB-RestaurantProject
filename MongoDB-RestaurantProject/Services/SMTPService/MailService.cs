using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Context.Settings;
using System.Net;
using System.Net.Mail;

namespace MongoDB_RestaurantProject.Services.SMTPService
{
    public class MailService : IMailService
    {
        private readonly SmtpSettings _settings;
        private readonly IMongoCollection<SmtpSettings> _mongoCollection;

        public MailService(IOptions<SmtpSettings> settings, IMongoCollection<SmtpSettings> mongoCollection)
        {
            _settings = settings.Value;
            _mongoCollection = mongoCollection;
        }

        public async Task CreateAsync(SmtpSettings entity)
        {
           await _mongoCollection
                .InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection
                .DeleteOneAsync(id);
        }

        public async Task<SmtpSettings> GetByIdAsync(string id)
        {
            return
                await _mongoCollection
                .Find(x=>x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<SmtpSettings>> GetListAsync()
        {
            return
                await _mongoCollection
                .Find(x=>true)
                .ToListAsync();
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var dbSettings = await _mongoCollection.Find(x => true).FirstOrDefaultAsync();
            var activeSettings = dbSettings ?? _settings;
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
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_settings.UserName, _settings.Password),
                EnableSsl = _settings.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            await smtp.SendMailAsync(mail);
        }

        public async Task UpdateAsync(SmtpSettings entity)
        {
            var filter = Builders<SmtpSettings>.Filter.Eq(x => x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
