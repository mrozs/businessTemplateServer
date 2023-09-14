using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tm.Core.ValueObjects;

namespace tm.Core.Entities
{
    public class User
    {
        public UserId Id { get; private set; }
        public Email Email { get; private set; }
        public UserName UserName { get; private set; }
        public Password Password { get; set; }
        public FullName FullName { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; private set; }

        public User(UserId id, Email email, UserName userName, Password password, FullName fullName, Role role, DateTime createdAt)
        {
            Id = id;
            Email = email;
            UserName = userName;
            Password = password;
            FullName = fullName;
            Role = role;
            CreatedAt = createdAt;
        }
    }
}
