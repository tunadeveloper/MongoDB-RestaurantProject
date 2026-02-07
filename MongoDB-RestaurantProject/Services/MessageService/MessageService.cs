
using MongoDB.Driver;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.Services.SMTPService;
using SharpCompress.Common;

namespace MongoDB_RestaurantProject.Services.MessageService
{
    public class MessageService : IMessageService
    {
        private readonly IMongoCollection<Message> _mongoCollection;
        private readonly IMailService _mailService;

        public MessageService(IMongoCollection<Message> mongoCollection, IMailService mailService)
        {
            _mongoCollection = mongoCollection;
            _mailService = mailService;
        }

        public async Task CreateAsync(Message message)
        {
            await _mongoCollection.InsertOneAsync(message);
            await _mailService.SendEmailAsync(
                "tunabusiness25@gmail.com",
                $"Yeni Mesaj - {message.NameSurname}",
                $"Kullanıcıdan Gelen Mesaj: <br> {message.UserMessage}"
                );
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<Message> GetByIdAsync(string id)
        {
            return
                await _mongoCollection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Message>> GetFavoriteListAsync()
        {
            return
                await _mongoCollection
                .Find(x => x.IsFavorite == true)
                .SortByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Message>> GetInboxListAsync()
        {
            return
                await _mongoCollection
                .Find(x => x.UserOrAdmin == "User")
                .SortByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Message>> GetListAsync()
        {
            return
                await _mongoCollection
                .Find(x => true)
                .ToListAsync();
        }

        public async Task<List<Message>> GetSentListAsync()
        {
            return
                await _mongoCollection
                .Find(x => x.UserOrAdmin == "Admin")
                .SortByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Message>> GetUnReadListAsync()
        {
            return
                await _mongoCollection
                .Find(x => x.IsRead == false && x.UserOrAdmin == "User")
                .ToListAsync();
        }

        public async Task SendMessageToUserAsync(Message message)
        {
            await _mongoCollection.InsertOneAsync(message);
            await _mailService.SendEmailAsync(
                message.Email,
                "Admin'den Cevap",
                message.UserMessage
                );
        }

        public async Task UpdateAsync(Message entity)
        {
            var filter = Builders<Message>.Filter.Eq(x => x.Id, entity.Id);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
