using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using TennisReservation.Data;
using TennisReservation.Models;

namespace TennisReservation.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly TennisReservationContext _context;

        public TrainerService(TennisReservationContext context)
        {
            _context = context;
        }
        public async Task<Trainer> CreateTrainerAsync(Trainer trainer)
        {
            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();
            return trainer;
        }

        public async Task DeleteTrainerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Trainer>> GetAllTrainersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Court>> GetAvailableCourtsForTrainerAsync(int trainerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TrainerAvailability>> GetAvailableTrainersForCourtAsync(int courtId, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            var trainersForCourt = await _context.Courts
                .Where(c => c.Id == courtId)
                .SelectMany(c => c.Trainers)
                .ToListAsync();

            var availableTrainers = await _context.TrainerAvailabilities
                .Where(ta => trainersForCourt.Select(t => t.Id).Contains(ta.TrainerId) &&
                ta.Date == date &&
                ta.IsAvailable &&
                ta.StartTime <= startTime &&
                ta.EndTime >= endTime)
                .ToListAsync();
            return availableTrainers;
        }

        public async Task<Trainer> GetTrainerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTrainerAsync(Trainer trainer)
        {
            throw new NotImplementedException();
        }
    }
}
