using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class ShooterRegistration
    {
        [Key]
        public string Id { get; set; } = default!;

        [ForeignKey("AssociationId")]
        public Association Association { get; set; } = default!;

        [ForeignKey("ShooterId")]
        public User Shooter { get; set; } = default!;

        [ForeignKey("CountryId")]
        public Country Country { get; set; } = default!;

        [ForeignKey("DateId")]
        public DateTime Date { get; set; } = default!;

        [Required]
        public string RegistrationNumber { get; set; } = default!;
    }
}
