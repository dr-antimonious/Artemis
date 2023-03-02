using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class Association
    {
        [Key]
        public string Id { get; set; } = default!;

        [Required]
        public string Name { get; set; } = default!;

        [ForeignKey("LocationId")]
        public Location Location { get; set; } = default!;

        [Required]
        public string Email { get; set; } = default!;

        [Required]
        public string PhoneNumber { get; set; } = default!;

        [Required]
        public string Color { get; set; } = default!;
    }
}
