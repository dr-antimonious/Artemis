using System.ComponentModel.DataAnnotations;
using Artemis.Contracts.Entities;

namespace Artemis.Contracts.DTOs
{
    public class CityCreateRequestDto
    {
        [Required(ErrorMessage = "City name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public Country Country { get; set; }
    }
}
