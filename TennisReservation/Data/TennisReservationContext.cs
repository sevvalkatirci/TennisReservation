using Microsoft.EntityFrameworkCore;
using TennisReservation.Models;

namespace TennisReservation.Data
{
    public class TennisReservationContext:DbContext
    {
        public TennisReservationContext(DbContextOptions<TennisReservationContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
