using System.ComponentModel.DataAnnotations;

namespace Artemis.Contracts.Entities
{
    public class City
    {
        [Key]
        public string Id { get; set; } = default!;

        [Required]
        public string Name { get; set; } = default!;
    }
}
