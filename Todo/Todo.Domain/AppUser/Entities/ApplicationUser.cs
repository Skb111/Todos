using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.AppUser.Entities
{
    public class ApplicationUser
    {
        public ApplicationUser(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = password;
        }
        public Guid ApplicationUserId { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public UserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
