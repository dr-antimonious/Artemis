using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class MedicalCheckUp
    {
        [Key]
        public string Id { get; set; } = default!;

        [ForeignKey("DoctorId")]
        public User Doctor { get; set; } = default!;

        [ForeignKey("ShooterId")]
        public User Shooter { get; set; } = default!;

        [ForeignKey("LocationId")]
        public Location Location { get; set; } = default!;

        [ForeignKey("DateId")]
        public DateTime Date { get; set; } = default!;

        [Required]
        public string Notes { get; set; } = default!;

        public MedicalCheckUp()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public MedicalCheckUp(
            User doctor,
            User shooter,
            Location location,
            DateTime date,
            string notes)
            : this()
        {
            this.Doctor = doctor;
            this.Shooter = shooter;
            this.Location = location;
            this.Date = date;
            this.Notes = notes;
        }

        public MedicalCheckUp(
            string id,
            User doctor,
            User shooter,
            Location location,
            DateTime date,
            string notes)
            : this(
                doctor,
                shooter,
                location,
                date,
                notes)
        {
            this.Id = id;
            this.Doctor = doctor;
            this.Shooter = shooter;
            this.Location = location;
            this.Date = date;
            this.Notes = notes;
        }
    }
}
