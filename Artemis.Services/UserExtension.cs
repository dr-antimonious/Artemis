using System.Security.Cryptography;
using System.Text;
using Artemis.Contracts.Entities;

namespace Artemis.Services
{
    public static class UserExtension
    {
        public static string GenerateId(this User user)
        {
            char[] userAsChars = (
                user.FirstName
                + user.AddtnlNames
                + user.LastName
                + user.DateOfBirth.Date
                + user.Gender
                + user.Email
                + user.PhoneNumber).ToCharArray();
            byte[] userAsByte = Encoding.UTF8.GetBytes(userAsChars);
            SHA512 sha512 = SHA512.Create();
            byte[] hashedUserBytes = sha512.ComputeHash(userAsByte);
            sha512.Dispose();
            string id = Convert.ToHexString(hashedUserBytes);
            user.Id = id;
        }
    }
}