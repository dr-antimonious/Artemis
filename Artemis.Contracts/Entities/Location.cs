using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis.Contracts.Entities
{
    public class Location
    {
        [Key]
        public string Id { get; set; } = default!;

        [ForeignKey("CityId")]
        public City City { get; set; } = default!;

        [ForeignKey("CountryId")]
        public Country Country { get; set; } = default!;
    }
}
