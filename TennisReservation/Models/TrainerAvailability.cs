namespace TennisReservation.Models
{
    public class TrainerAvailability
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
