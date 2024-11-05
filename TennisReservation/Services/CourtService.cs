using Microsoft.EntityFrameworkCore;
using TennisReservation.Data;
using TennisReservation.Models;

namespace TennisReservation.Services
{
    public class CourtService : ICourtService
    {
        private readonly TennisReservationContext _context;
        public CourtService(TennisReservationContext context)
        {
            _context = context;
        }

        public async Task<bool> AssignTrainerToCourtAsync(int courtId, int trainerId)
        {
            var court=await _context.Courts.Include(c=>c.Trainers).FirstOrDefaultAsync(c=>c.Id==courtId);
            var trainer=await _context.Trainers.FindAsync(trainerId);
            
            if(trainer==null||court==null)
            {
                return false;
            }
            if(!court.Trainers.Contains(trainer))
            {
                court.Trainers.Add(trainer);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<Court> CreateCourtAsync(Court court)
        {
           _context.Courts.Add(court);
            await _context.SaveChangesAsync();
            return court;
        }

        public async Task DeleteCourtAsync(int id)
        {
            var court=await _context.Courts.FirstOrDefaultAsync(x => x.Id==id);
            if (court!=null)
            {
                _context.Courts.Remove(court);
                await _context.SaveChangesAsync();
            }
                
        }

        public async Task<IEnumerable<Court>> GetAllCourtsAsync()
        {
            return await _context.Courts.Include(c=>c.Trainers).ToListAsync();
        }

        public async Task<IEnumerable<Trainer>> GetAvailableTrainersForCourtAsync(int courtId)
        {
            var court=await _context.Courts.Include(c=>c.Trainers).FirstOrDefaultAsync(c=>c.Id==courtId);
            if (court == null) return null;

            var allTrainers = court.Trainers.ToList();
            return allTrainers;
            
        }

        public async Task<IEnumerable<CourtAvailability>> GetCourtAvailabilityAsync(int courtId, DateTime date)
        {
            return await _context.CourtAvailabilities
                .Where(ca=>ca.CourtId==courtId && ca.Date==date&&ca.IsAvailable).ToListAsync();
        }

        public async Task<Court> GetCourtByIdAsync(int id)
        {
            return await _context.Courts.Include(c => c.Trainers).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCourtAsync(Court court)
        {
            _context.Courts.Update(court);
            await _context.SaveChangesAsync();
        }
    }
}
