using System.Security.Cryptography;
using System.Text;
using Artemis.Contracts.Entities;

namespace Artemis.Services
{
    public static class UserExtension
    {
        public static void GenerateId(this User user)
        {
            char[] userAsChars = (
                user.FirstName
                + user.AddtnlNames
                + user.LastName
                + user.DateOfBirth.Date
                + user.Gender
                + user.Email
                + user.PhoneNumber
                + user.IsCoach
                + user.IsManager
                + user.IsDoctor
                + user.IsShooter).ToCharArray();
            user.Id = Convert.ToHexString(SHA512.HashData(Encoding.UTF8.GetBytes(userAsChars)));
        }
    }
}