using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TennisReservation.Models;
using TennisReservation.Services;

namespace TennisReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtController : ControllerBase
    {
        private readonly ICourtService _courtService;

        public CourtController(ICourtService courtService)
        {
            _courtService = courtService;
        }

        // GET: api/Court
        [HttpGet]
        public async Task<IActionResult> GetAllCourts()
        {
            var courts = await _courtService.GetAllCourtsAsync();
            return Ok(courts);
        }

        // POST: api/Court
        [HttpPost]
        public async Task<IActionResult> CreateCourt([FromBody] Court court)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCourt = await _courtService.CreateCourtAsync(court);
            return CreatedAtAction(nameof(GetCourtById), new { id = createdCourt.Id }, createdCourt);
        }

        // GET: api/Court/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourtById(int id)
        {
            var court = await _courtService.GetCourtByIdAsync(id);
            if (court == null)
            {
                return NotFound();
            }
            return Ok(court);
        }

        // PUT: api/Court/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourt(int id, [FromBody] Court court)
        {
            if (!ModelState.IsValid || id != court.Id)
            {
                return BadRequest(ModelState);
            }

            await _courtService.UpdateCourtAsync(court);
            return NoContent();
        }

        // DELETE: api/Court/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourt(int id)
        {
            await _courtService.DeleteCourtAsync(id);
            return NoContent();
        }

        // GET: api/Court/{courtId}/trainers
        [HttpGet("{courtId}/trainers")]
        public async Task<IActionResult> GetAvailableTrainersForCourt(int courtId)
        {
            var trainers = await _courtService.GetAvailableTrainersForCourtAsync(courtId);
            return Ok(trainers);
        }

        // POST: api/Court/{courtId}/assign-trainer/{trainerId}
        [HttpPost("{courtId}/assign-trainer/{trainerId}")]
        public async Task<IActionResult> AssignTrainerToCourt(int courtId, int trainerId)
        {
            var success = await _courtService.AssignTrainerToCourtAsync(courtId, trainerId);
            if (!success)
            {
                return BadRequest("Unable to assign trainer to court.");
            }

            return Ok("Trainer assigned to court successfully.");
        }

        // GET: api/Court/{courtId}/availability
        [HttpGet("{courtId}/availability")]
        public async Task<IActionResult> GetCourtAvailability(int courtId, [FromQuery] DateTime date)
        {
            var availability = await _courtService.GetCourtAvailabilityAsync(courtId, date);
            return Ok(availability);
        }
    }
}

