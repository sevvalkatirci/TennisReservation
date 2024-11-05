using Microsoft.EntityFrameworkCore;
using TennisReservation.Data;
using TennisReservation.Models;

namespace TennisReservation.Services
{
    public class ReservationService : IReservationService
    {
        private readonly TennisReservationContext _context;
        public ReservationService(TennisReservationContext context)
        {
            _context=context;
        }

        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            if(await IsCourtAvailable(reservation.CourtId, reservation.ReservationDate, reservation.StartTime, reservation.EndTime))
            {
                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();
                return reservation;
            }
            throw new Exception("Court is not available for the selected time.");
        }

        public async Task<IEnumerable<Reservation>> GetUserReservationsAsync(int userId)
        {
            return await _context.Reservations
                .Where(r => r.UserId == userId)
                .Include(r => r.Court)
                .Include(r => r.Trainer)
                .ToListAsync();
        }

        public async Task<bool> IsCourtAvailable(int courtId, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            return !await _context.Reservations.AnyAsync(r =>
            r.CourtId == courtId &&
            r.ReservationDate == date &&
            ((r.StartTime < endTime && r.EndTime > startTime)));
        }
    }
}
