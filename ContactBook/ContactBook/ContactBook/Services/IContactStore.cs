using ContactBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactBook.ViewModels
{
    public interface IContactStore
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact> Get(int id);
        Task Add(Contact contact);
        Task Update(Contact contact);
        Task Delete(int id);
    }
}
