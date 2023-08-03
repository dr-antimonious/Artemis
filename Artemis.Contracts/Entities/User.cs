using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Artemis.Contracts.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [PersonalData]
        public string FirstName { get; set; } = default!;

        [PersonalData]
        public string AdditionalNames { get; set; } = default!;

        [Required]
        [PersonalData]
        public string LastName { get; set; } = default!;

        [Required]
        [PersonalData]
        public DateTime DateOfBirth { get; set; } = default!;

        [Required]
        [PersonalData]
        public char Gender { get; set; } = default!;

        public User()
        {
            this.Id = Guid.NewGuid().ToString();
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
            string phoneNumber)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.AdditionalNames = additionalNames;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }
    }
}
