using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Areas.Admin.Models;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.MessageDTOs;
using MongoDB_RestaurantProject.Services.MessageService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var inboxValues = await _messageService.GetInboxListAsync();
            var sentValues = await _messageService.GetSentListAsync();
            var unreadValues = await _messageService.GetUnReadListAsync();
            var favoriteValues = await _messageService.GetFavoriteListAsync();

            var model = new MessageListViewModel
            {
                InboxMessages = _mapper.Map<List<ResultMessageDTO>>(inboxValues),
                SentMessages = _mapper.Map<List<ResultMessageDTO>>(sentValues),
                UnreadMessages = _mapper.Map<List<ResultMessageDTO>>(unreadValues),
                FavoriteMessages = _mapper.Map<List<ResultMessageDTO>>(favoriteValues),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDTO createMessageDTO)
        {
            createMessageDTO.UserOrAdmin = "Admin";
            createMessageDTO.CreatedAt = DateTime.Now;
            createMessageDTO.IsRead = true;
            createMessageDTO.IsFavorite = false;
            var entity = _mapper.Map<Message>(createMessageDTO);
            await _messageService.SendMessageToUserAsync(entity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteMessage(string id)
        {
            await _messageService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ToggleFavorite(string id)
        {
            var message = await _messageService.GetByIdAsync(id);
            message.IsFavorite = !message.IsFavorite;
            await _messageService.UpdateAsync(message);
            return RedirectToAction("Index");
        }
    }
}
