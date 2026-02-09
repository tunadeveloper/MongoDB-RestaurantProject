using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.ProductReviewDTOs;

namespace MongoDB_RestaurantProject.ViewComponents.Product
{
    public class _CreateProductReviewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke(CreateProductReviewDTO model)
        {
            return View(model);
        }
    }
}
