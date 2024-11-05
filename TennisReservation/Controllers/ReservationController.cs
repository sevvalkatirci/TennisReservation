using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TennisReservation.Models;
using TennisReservation.Services;

namespace TennisReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(ReservationService reservationService)
        {
            _reservationService=reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdReservation = await _reservationService.CreateReservationAsync(reservation);
                return CreatedAtAction(nameof(GetUserReservations), new { id = reservation.UserId }, createdReservation);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserReservations(int userId)
        {
            var reservation=await _reservationService.GetUserReservationsAsync(userId);
            return Ok(reservation);
        }
    }
}
