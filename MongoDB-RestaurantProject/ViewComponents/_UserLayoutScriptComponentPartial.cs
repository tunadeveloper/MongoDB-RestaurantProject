using Microsoft.AspNetCore.Mvc;

namespace MongoDB_RestaurantProject.ViewComponents
{
    public class _UserLayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
