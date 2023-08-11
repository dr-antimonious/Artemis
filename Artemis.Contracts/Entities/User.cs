using System.ComponentModel.DataAnnotations;
using Artemis.Contracts.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Artemis.Contracts.Entities
{
    public class User : IdentityUser<string>
    {
        [Key]
        public override string Id { get; set; } = null!;

        [Required(ErrorMessage = "First name is required"), ProtectedPersonalData]
        public string FirstName { get; set; } = null!;

        [ProtectedPersonalData]
        public string AdditionalNames { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required"), ProtectedPersonalData]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Date of birth is required"), ProtectedPersonalData]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required"), ProtectedPersonalData]
        public char Gender { get; set; }

        [Required(ErrorMessage = "Email is required"), ProtectedPersonalData, EmailAddress]
        public new string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required"), ProtectedPersonalData, Phone]
        public new string PhoneNumber { get; set; } = null!;

        public List<IMatch> Matches { get; set; }

        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Matches = new List<IMatch>();
        }

        public User(
            string firstName,
            string additionalNames,
            string lastName,
            DateTime dateOfBirth,
            char gender,
            string email,
            string phoneNumber)
            : this()
        {
            this.FirstName = firstName;
            this.AdditionalNames = additionalNames;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }

        public User(
            string id,
            string firstName,
            string additionalNames,
            string lastName,
            DateTime dateOfBirth,
            char gender,
            string email,
            string phoneNumber,
            List<IMatch> matches)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.AdditionalNames = additionalNames;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Matches = matches;
        }
    }
}
