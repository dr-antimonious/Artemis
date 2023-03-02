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

        public Association()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Association(
            string name,
            Location location,
            string email,
            string phoneNumber,
            string color)
            : this()
        {
            this.Name = name;
            this.Location = location;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Color = color;
        }

        public Association(
            string id,
            string name,
            Location location,
            string email,
            string phoneNumber,
            string color)
            : this(
                name,
                location,
                email,
                phoneNumber,
                color)
        {
            this.Id = id;
        }
    }
}
