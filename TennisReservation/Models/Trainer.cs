namespace TennisReservation.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }

        // Navigation property to the Court
        public ICollection<Court> Courts { get; set; }=new List<Court>();
        public ICollection<TrainerAvailability> AvailabilitySlots { get; set; } = new List<TrainerAvailability>();

    }

}
