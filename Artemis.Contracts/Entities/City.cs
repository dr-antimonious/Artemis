using System.ComponentModel.DataAnnotations;
using Artemis.Contracts.DTOs;

namespace Artemis.Contracts.Entities
{
    public class City
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "City name is required")]
        public string Name { get; set; } = null!;

        public List<Country> Countries { get; set; }

        public List<Location> Locations { get; set; }

        public City()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Countries = new List<Country>();
            this.Locations = new List<Location>();
        }

        public City(string name)
            : this()
        {
            this.Name = name;
        }

        public City(
            string id,
            string name,
            List<Country> countries,
            List<Location> locations)
        {
            this.Id = id;
            this.Name = name;
            this.Countries = countries;
            this.Locations = locations;
        }

        public City(CityCreateRequestDto createRequest)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = createRequest.Name;
            this.Countries = new List<Country> {createRequest.Country};
            this.Locations = new List<Location>();
        }
    }
}
