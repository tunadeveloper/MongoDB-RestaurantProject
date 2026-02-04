using Microsoft.AspNetCore.Mvc;

namespace MongoDB_RestaurantProject.Areas.Admin.ViewComponents
{
    public class _AdminLayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
