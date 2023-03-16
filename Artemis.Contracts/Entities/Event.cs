using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class Event
    {
        [Key]
        public string Id { get; set; } = default!;

        [Required(ErrorMessage = "Coach is required")]
        [ForeignKey("CoachId")]
        public User Coach { get; set; } = default!;

        [Required(ErrorMessage = "Shooter is required")]
        [ForeignKey("ShooterId")]
        public User Shooter { get; set; } = default!;

        [Required(ErrorMessage = "Date is required")]
        [ForeignKey("DateId")]
        public DateTime Date { get; set; } = default!;

        [Required(ErrorMessage = "Location is required")]
        [ForeignKey("LocationId")]
        public Location Location { get; set; } = default!;

        [Required(ErrorMessage = "Notes are required")]
        public string Notes { get; set; } = default!;

        [Required(ErrorMessage = "Must define if event is a match")]
        public bool IsMatch { get; set; } = default!;

        public Event()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Event(
            User coach,
            User shooter,
            DateTime date,
            Location location,
            string notes,
            bool isMatch)
            : this()
        {
            this.Coach = coach;
            this.Shooter = shooter;
            this.Date = date;
            this.Location = location;
            this.Notes = notes;
            this.IsMatch = isMatch;
        }

        public Event(
            string id,
            User coach,
            User shooter,
            DateTime date,
            Location location,
            string notes,
            bool isMatch)
            : this(
                coach,
                shooter,
                date,
                location,
                notes,
                isMatch)
        {
            this.Id = id;
        }
    }
}
