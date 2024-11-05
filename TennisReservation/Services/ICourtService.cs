using TennisReservation.Models;

namespace TennisReservation.Services
{
    public interface ICourtService
    {
        Task<IEnumerable<Court>> GetAllCourtsAsync();
        Task<Court> CreateCourtAsync(Court court);
        Task<Court>GetCourtByIdAsync(int id);
        Task UpdateCourtAsync(Court court);
        Task DeleteCourtAsync(int id);
        Task<IEnumerable<Trainer>> GetAvailableTrainersForCourtAsync(int courtId);
        Task<bool> AssignTrainerToCourtAsync(int courtId, int trainerId);
        Task<IEnumerable<CourtAvailability>> GetCourtAvailabilityAsync(int courtId,DateTime date);

    }
}
