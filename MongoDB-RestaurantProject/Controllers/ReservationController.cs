using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.ReservationDTOs;
using MongoDB_RestaurantProject.Services.ReservationService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        public IActionResult CreateReservation()=>View();

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDTO createReservationDTO)
        {
            var entity = _mapper.Map<Reservation>(createReservationDTO);
            await _reservationService.CreateAsync(entity);
            return View();
        }
    }
}
