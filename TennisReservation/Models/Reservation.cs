namespace TennisReservation.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CourtId { get; set; }
        public Court Court { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
