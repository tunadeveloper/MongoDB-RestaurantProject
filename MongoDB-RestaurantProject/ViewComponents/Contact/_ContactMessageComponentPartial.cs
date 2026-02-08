using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.MessageDTOs;

namespace MongoDB_RestaurantProject.ViewComponents.Contact
{
    public class _ContactMessageComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new CreateMessageDTO());
        }
    }
}
