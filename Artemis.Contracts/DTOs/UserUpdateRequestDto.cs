using System.ComponentModel.DataAnnotations;

namespace Artemis.Contracts.DTOs
{
    public class UserUpdateRequestDto : UserRequestBaseDto
    {
        [Required(ErrorMessage = "User ID is required")]
        public string Id { get; set; }
    }
}
