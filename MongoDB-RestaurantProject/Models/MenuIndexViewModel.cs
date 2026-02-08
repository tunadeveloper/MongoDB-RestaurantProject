using MongoDB_RestaurantProject.DataTransferObject.CategoryDTOs;
using MongoDB_RestaurantProject.DataTransferObject.ProductDTOs;

namespace MongoDB_RestaurantProject.Models
{
    public class MenuIndexViewModel
    {
        public List<ResultCategoryDTO> Categories { get; set; }
        public List<ResultProductDTO> Products { get; set; }
    }
}
