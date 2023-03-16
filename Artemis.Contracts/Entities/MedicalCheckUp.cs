using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class MedicalCheckUp
    {
        [Key]
        public string Id { get; set; } = default!;

        [Required(ErrorMessage = "Doctor is required")]
        [ForeignKey("DoctorId")]
        public User Doctor { get; set; } = default!;

        [Required(ErrorMessage = "Shooter is required")]
        [ForeignKey("ShooterId")]
        public User Shooter { get; set; } = default!;

        [Required(ErrorMessage = "Location is required")]
        [ForeignKey("LocationId")]
        public Location Location { get; set; } = default!;

        [Required(ErrorMessage = "Date is required")]
        [ForeignKey("DateId")]
        public DateTime Date { get; set; } = default!;

        [Required(ErrorMessage = "Notes are required")]
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
