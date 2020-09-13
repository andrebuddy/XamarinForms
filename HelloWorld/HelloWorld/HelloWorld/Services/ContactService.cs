using HelloWorld.Models;
using HelloWorld.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public class ContactService
    {
        private IRepository<ContactBook> _repository;

        public ContactService(IRepository<ContactBook> repository)
        {
            _repository = repository;
        }

        public async Task<List<ContactBook>> GetContacts()
        {
            var contacts = await _repository.Read();

            return contacts;
        }

        public ContactBook GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateContact(ContactBook contact)
        {
            var nRows = await _repository.Update(contact);

            return nRows > 0;
        }

        public async Task<bool> AddContact(ContactBook contact)
        {
            var nRows = await _repository.Create(contact);

            return nRows > 0;
        }

        public async Task<bool> DeleteContact(ContactBook contact)
        {
            var nRows = await _repository.Delete(contact);

            return nRows > 0;
        }

    }
}
