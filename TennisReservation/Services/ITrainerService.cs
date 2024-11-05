using TennisReservation.Models;

namespace TennisReservation.Services
{
    public interface ITrainerService
    {
        Task<Trainer> CreateTrainerAsync(Trainer trainer);
        Task<Trainer> GetTrainerByIdAsync(int id);
        Task<IEnumerable<Trainer>> GetAllTrainersAsync();
        Task UpdateTrainerAsync(Trainer trainer);
        Task DeleteTrainerAsync(int id);
        Task<IEnumerable<Court>> GetAvailableCourtsForTrainerAsync(int trainerId);
        Task<IEnumerable<TrainerAvailability>> GetAvailableTrainersForCourtAsync(int courtId, DateTime date, TimeSpan startTime, TimeSpan endTime);
    }
}
