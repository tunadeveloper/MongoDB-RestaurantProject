using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.MessageDTOs;
using MongoDB_RestaurantProject.Services.MessageService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IValidator<Message> _validator;
        private readonly IMapper _mapper;
        public MessageController(IMessageService messageService, IMapper mapper, IValidator<Message> validator)
        {
            _messageService = messageService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDTO createMessageDTO)
        {
            createMessageDTO.CreatedAt = DateTime.Now;
            createMessageDTO.UserOrAdmin = "User";
            createMessageDTO.IsRead = false;
            createMessageDTO.IsFavorite = false;
            var entity = _mapper.Map<Message>(createMessageDTO);
            await _messageService.CreateAsync(entity);
            return RedirectToAction("Index", "Contact");
        }
    }
}
