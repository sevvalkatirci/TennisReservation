namespace TennisReservation.Models
{
    public class Court
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string SurfaceType { get; set; }

        // Navigation property to trainers
        public ICollection<Trainer> Trainers { get; set; }=new List<Trainer>();
        public ICollection<CourtAvailability> AvailabilitySlots { get; set; } = new List<CourtAvailability>();

    }

}
