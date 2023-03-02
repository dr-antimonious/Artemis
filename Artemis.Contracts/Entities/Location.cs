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

        public Location()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Location(City city, Country country)
            : this()
        {
            this.City = city;
            this.Country = country;
        }

        public Location(
            string id,
            City city,
            Country country)
            : this(city, country)
        {
            this.Id = id;
            this.City = city;
            this.Country = country;
        }
    }
}
