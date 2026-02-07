using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Areas.Admin.Models;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.PromationDTOs;
using MongoDB_RestaurantProject.DataTransferObject.ReservationDTOs;
using MongoDB_RestaurantProject.Services.ReservationService;
using System.Threading.Tasks;

namespace MongoDB_RestaurantProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var allList = await _reservationService.GetAllOrderedAsync();
            var pendingList = await _reservationService.GetByStatusAsync(null);
            var approvedList = await _reservationService.GetByStatusAsync(true);
            var cancelledList = await _reservationService.GetByStatusAsync(false);

            var model = new ReservationListViewModel
            {
                AllReservations = _mapper.Map<List<ResultReservationDTO>>(allList),
                ApprovedReservations = _mapper.Map<List<ResultReservationDTO>>(approvedList),
                PendingReservations = _mapper.Map<List<ResultReservationDTO>>(pendingList),
                CancelledReservations = _mapper.Map<List<ResultReservationDTO>>(cancelledList),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDTO createReservationDTO)
        {
            var entity= _mapper.Map<Reservation>(createReservationDTO);
            await _reservationService.CreateAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDTO updateReservationDTO)
        {
            var entity = _mapper.Map<Reservation>(updateReservationDTO);
            await _reservationService.UpdateAsync(entity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteReservation(string id)
        {
            await _reservationService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatus(string id, bool status)
        {
            var list = await _reservationService.GetByIdAsync(id);
            if(list != null)
                list.Status = status;
                await _reservationService.UpdateAsync(list);

            return RedirectToAction("Index");
        }
    }
}
