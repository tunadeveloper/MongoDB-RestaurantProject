using Microsoft.AspNetCore.Mvc;

namespace MongoDB_RestaurantProject.ViewComponents.UserLayout
{
    public class _UserLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
