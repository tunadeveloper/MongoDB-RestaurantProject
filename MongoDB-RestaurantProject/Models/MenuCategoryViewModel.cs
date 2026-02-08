using MongoDB_RestaurantProject.DataTransferObject.ProductDTOs;

namespace MongoDB_RestaurantProject.Models
{
    public class MenuCategoryViewModel
    {
        public string CategoryName { get; set; }
        public List<ResultProductDTO> Products { get; set; }
    }
}
