using Artemis.Contracts.Entities;
using System.ComponentModel.DataAnnotations;

namespace Artemis.Contracts.DTOs
{
    public class LocationCreateRequestDto
    {
        [Required(ErrorMessage = "Location name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public Country Country { get; set; }

        [Required(ErrorMessage = "City is required")]
        public City City { get; set; }
    }
}
