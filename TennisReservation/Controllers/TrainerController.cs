using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TennisReservation.Models;
using TennisReservation.Services;

namespace TennisReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        // POST: api/Trainer
        [HttpPost]
        public async Task<IActionResult> CreateTrainer([FromBody] Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTrainer = await _trainerService.CreateTrainerAsync(trainer);
            return CreatedAtAction(nameof(GetTrainerById), new { id = createdTrainer.Id }, createdTrainer);
        }

        // GET: api/Trainer/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainerById(int id)
        {
            var trainer = await _trainerService.GetTrainerByIdAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }
            return Ok(trainer);
        }

        // GET: api/Trainer
        [HttpGet]
        public async Task<IActionResult> GetAllTrainers()
        {
            var trainers = await _trainerService.GetAllTrainersAsync();
            return Ok(trainers);
        }

        // PUT: api/Trainer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainer(int id, [FromBody] Trainer trainer)
        {
            if (!ModelState.IsValid || id != trainer.Id)
            {
                return BadRequest(ModelState);
            }

            await _trainerService.UpdateTrainerAsync(trainer);
            return NoContent();
        }

        // DELETE: api/Trainer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            await _trainerService.DeleteTrainerAsync(id);
            return NoContent();
        }

        // GET: api/Trainer/{trainerId}/available-courts
        [HttpGet("{trainerId}/available-courts")]
        public async Task<IActionResult> GetAvailableCourtsForTrainer(int trainerId)
        {
            var courts = await _trainerService.GetAvailableCourtsForTrainerAsync(trainerId);
            return Ok(courts);
        }

        // GET: api/Trainer/available-for-court
        [HttpGet("available-for-court")]
        public async Task<IActionResult> GetAvailableTrainersForCourt(
            [FromQuery] int courtId,
            [FromQuery] DateTime date,
            [FromQuery] TimeSpan startTime,
            [FromQuery] TimeSpan endTime)
        {
            var trainers = await _trainerService.GetAvailableTrainersForCourtAsync(courtId, date, startTime, endTime);
            return Ok(trainers);
        }
    }
}
