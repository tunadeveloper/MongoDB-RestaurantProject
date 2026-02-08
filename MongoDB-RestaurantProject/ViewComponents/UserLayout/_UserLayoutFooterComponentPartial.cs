using Microsoft.AspNetCore.Mvc;

namespace MongoDB_RestaurantProject.ViewComponents.UserLayout
{
    public class _UserLayoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
