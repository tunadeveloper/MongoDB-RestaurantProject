using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.Context.Entities;
using MongoDB_RestaurantProject.DataTransferObject.ReservationDTOs;
using MongoDB_RestaurantProject.Services.ReservationService;
using Org.BouncyCastle.Ocsp;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace MongoDB_RestaurantProject.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IValidator<Reservation> _validator;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService, IMapper mapper, IValidator<Reservation> validator)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _validator = validator;
        }

        public IActionResult CreateReservation()=>View();

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDTO createReservationDTO, string resDate, string resTime)
        {
            string combinedDateTimeString = $"{resDate} {resTime}";
            if (DateTime.TryParse(combinedDateTimeString, out DateTime combinedDateTime))
            {
                createReservationDTO.ReservationAt = combinedDateTime;
            }
            createReservationDTO.Status = null;
            var entity = _mapper.Map<Reservation>(createReservationDTO);

            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                foreach(var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(createReservationDTO);
            }

            await _reservationService.CreateAsync(entity);
            return View();
        }
    }
}
