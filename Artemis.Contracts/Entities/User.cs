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
        public string AddtnlNames { get; set; } = default!;

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
            string addtnlNames,
            string lastName,
            DateTime dateOfBirth,
            char gender,
            string email,
            string phoneNumber)
            : this()
        {
            this.FirstName = firstName;
            this.AddtnlNames = addtnlNames;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }

        public User(
            string id,
            string firstName,
            string addtnlNames,
            string lastName,
            DateTime dateOfBirth,
            char gender,
            string email,
            string phoneNumber)
            : this(
                firstName,
                addtnlNames,
                lastName,
                dateOfBirth,
                gender,
                email,
                phoneNumber)
        {
            this.Id = id;
        }
    }
}
