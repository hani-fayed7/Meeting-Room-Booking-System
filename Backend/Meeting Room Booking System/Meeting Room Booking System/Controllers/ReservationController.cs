using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Meeting_Room_Booking_System.Resources;
using Meeting_Room_Booking_System.Validators;
using Microsoft.AspNetCore.Mvc;
using MRBS.Core.Models;
using MRBS.Services.Interface;

namespace Meeting_Room_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            this._mapper = mapper;
            this._reservationService = reservationService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ReservationResource>>> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservations();
            var reservationResources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationResource>>(reservations);

            return Ok(reservationResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationResource>> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationById(id);
            var reservationResource = _mapper.Map<Reservation, ReservationResource>(reservation);

            return Ok(reservationResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<ReservationResource>> CreateReservation([FromBody] SaveReservationResource saveReservationResource)
        {
            var validator = new SaveReservationResourceValidator();
            var validationResult = await validator.ValidateAsync(saveReservationResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var reservationToCreate = _mapper.Map<SaveReservationResource, Reservation>(saveReservationResource);

            var newReservation = await _reservationService.CreateReservation(reservationToCreate);

            var reservation = await _reservationService.GetReservationById(newReservation.PkReservationId);

            var reservationResource = _mapper.Map<Reservation, ReservationResource>(reservation);

            return Ok(reservationResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _reservationService.GetReservationById(id);

            await _reservationService.DeleteReservation(reservation);

            return NoContent();
        }
    }
}