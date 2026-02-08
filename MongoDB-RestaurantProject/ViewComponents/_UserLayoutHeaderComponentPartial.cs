using Microsoft.AspNetCore.Mvc;

namespace MongoDB_RestaurantProject.ViewComponents
{
    public class _UserLayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
