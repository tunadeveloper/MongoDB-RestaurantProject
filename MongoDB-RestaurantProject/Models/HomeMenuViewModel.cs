using MongoDB_RestaurantProject.DataTransferObject.ProductDTOs;

namespace MongoDB_RestaurantProject.Models
{
    public class HomeMenuViewModel
    {
        public List<ResultProductDTO> Main { get; set; }
        public List<ResultProductDTO> Soup { get; set; }
        public List<ResultProductDTO> Dessert { get; set; }
        public List<ResultProductDTO> Cucumber { get; set; }
    }
}
