
using TennisReservation.Models;

namespace TennisReservation.Services
{
    public interface IReservationService
    {
        Task<Reservation> CreateReservationAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> GetUserReservationsAsync(int userId);
        Task<bool> IsCourtAvailable(int courtId,DateTime date,TimeSpan startTime,TimeSpan endTime);
    }
}
