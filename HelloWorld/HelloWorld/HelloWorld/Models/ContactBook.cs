using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    public class ContactBook
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Blocked { get; set; }
    }
}
