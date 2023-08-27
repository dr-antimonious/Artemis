using System.ComponentModel.DataAnnotations;

namespace Artemis.Contracts.DTOs
{
    public class RegistrationRequestDto : UserRequestBaseDto
    {
        [Required(ErrorMessage = "Password is required")]
        public string PasswordHash { get; set; } = null!;
    }
}
