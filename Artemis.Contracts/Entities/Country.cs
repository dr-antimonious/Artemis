using System.ComponentModel.DataAnnotations;

namespace Artemis.Contracts.Entities
{
    public class Country
    {
        [Key]
        public string Id { get; set; } = default!;

        [Required]
        public string Name { get; set; } = default!;
    }
}
