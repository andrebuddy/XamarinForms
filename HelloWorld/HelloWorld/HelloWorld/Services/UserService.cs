using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>
        {
            new User {Id = 1, Name = "Jenny Dalby", Description = "My name is Jenny Dalby" },
            new User {Id = 2, Name = "Jonv", Description = "Im new in Instagram" },
            new User {Id = 3, Name = "Rachel Martin", Description = "My name is Rachel" },
            new User {Id = 4, Name = "Nivan Jay", Description = "Im new in Instagram" },
            new User {Id = 5, Name = "SanazZ", Description = "My name is SanazZ" },
            new User {Id = 6, Name = "NextLab", Description = "Im new in Instagram" },
            new User {Id = 7, Name = "Alex B", Description = "My name is Alex" },
            new User {Id = 8, Name = "Tara Chang", Description = "Im new in Instagram" },
            new User {Id = 9, Name = "Tom K", Description = "My name is Tom" },
        };

        public User GetUser(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }
}
