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
        public DbSet<Court> Courts {  get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<CourtAvailability> CourtAvailabilities { get; set; }
        public DbSet<TrainerAvailability> TrainerAvailabilities { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<Trainer>()
            .HasMany(t => t.Courts)
            .WithMany(c => c.Trainers)
            .UsingEntity(j => j.ToTable("TrainerCourts"));
        }
    }
}
