using Microsoft.AspNetCore.Mvc;

namespace MongoDB_RestaurantProject.ViewComponents.Home
{
    public class _HomeChefComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
