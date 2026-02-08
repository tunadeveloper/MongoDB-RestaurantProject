using Microsoft.AspNetCore.Mvc;

namespace MongoDB_RestaurantProject.ViewComponents.Home
{
    public class _HomeBlogComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
