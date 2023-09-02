using System;
using BCrypt.Net;
using System.Collections.Generic;

namespace Api.Data.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<UserRole> UserRoles { get; set; }

        public void SetPassword(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);

            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }
}

