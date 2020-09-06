using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld.Services
{
    public class ContactService
    {
        private List<ContactBook> _contacts = new List<ContactBook>
        {
            new ContactBook { Id = 1, FirstName = "Mosh", LastName = "Hamedani", Email = "mosh@hamedani.com", Blocked = false, Phone = "+351961373344" },
            new ContactBook { Id = 2, FirstName = "Andre", LastName = "Santos", Email = "andre@santos.com", Blocked = false, Phone = "+31636475519" },
            new ContactBook { Id = 3, FirstName = "Joana", LastName = "Farinha", Email = "joana@farinha.com", Blocked = false, Phone = "+31784536717" },
            new ContactBook { Id = 4, FirstName = "Antonio", LastName = "Alves", Email = "antonio@alves.com", Blocked = false, Phone = "+3176093856" }
        };

        public IList<ContactBook> GetContacts()
        {
            return _contacts;
        }

        public ContactBook GetContact(int id)
        {
            return _contacts.First(c => c.Id == id);
        }
    }
}
