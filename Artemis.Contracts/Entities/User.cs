using Microsoft.AspNetCore.Identity;

namespace Artemis.Contracts.Entities
{
    public class User : IdentityUser
    {
        public string Id { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string AddtnlNames { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public DateTime DateOfBirth { get; set; } = default!;

        public char Gender { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string Password { get; set; } = default!;

        public bool IsCoach { get; set; } = default!;

        public bool IsManager { get; set; } = default!;

        public bool IsDoctor { get; set; } = default!;

        public bool IsShooter { get; set; } = default!;

        public User()
        {
        }

        public User(
            string firstName,
            string addtnlNames,
            string lastName,
            DateTime dateOfBirth,
            char gender,
            string email,
            string phoneNumber,
            string password,
            bool isCoach,
            bool isManager,
            bool isDoctor,
            bool isShooter)
            : this()
        {
            this.FirstName = firstName;
            this.AddtnlNames = addtnlNames;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Password = password;
            this.IsCoach = isCoach;
            this.IsManager = isManager;
            this.IsDoctor = isDoctor;
            this.IsShooter = isShooter;
        }

        public User(
            string id,
            string firstName,
            string addtnlNames,
            string lastName,
            DateTime dateOfBirth,
            char gender,
            string email,
            string phoneNumber,
            string password,
            bool isCoach,
            bool isManager,
            bool isDoctor,
            bool isShooter)
            : this(
                firstName,
                addtnlNames,
                lastName,
                dateOfBirth,
                gender,
                email,
                phoneNumber,
                password,
                isCoach,
                isManager,
                isDoctor,
                isShooter)
        {
            this.Id = id;
        }
    }
}
