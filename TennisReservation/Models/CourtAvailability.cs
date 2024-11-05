namespace TennisReservation.Models
{
    public class CourtAvailability
    {
        public int Id { get; set; }
        public int CourtId { get; set; }
        public Court Court { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
