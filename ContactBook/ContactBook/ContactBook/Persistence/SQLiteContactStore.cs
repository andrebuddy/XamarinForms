using ContactBook.Models;
using ContactBook.Persistence;
using ContactBook.ViewModels;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactBook.Services
{
    public class SQLiteContactStore : IContactStore
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteContactStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Contact>();
        }

        public async Task Add(Contact contact)
        {
            await _connection.InsertAsync(contact);
        }

        public async Task<Contact> Get(int id)
        {
            return await _connection.Table<Contact>()
                .Where(contact => contact.Id == id)
                .FirstAsync();
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _connection.Table<Contact>()
                .ToListAsync();
        }

        public async Task Update(Contact contact)
        {
            var contactInDb = await _connection.Table<Contact>()
                .Where(_contact => _contact.Id == contact.Id)
                .FirstAsync();

            if (contactInDb != null)
            {
                await _connection.UpdateAsync(contact);
            }
        }

        public async Task Delete(int id)
        {
            var contactInDb = await _connection.Table<Contact>()
                .Where(_contact => _contact.Id == id)
                .FirstAsync();

            if (contactInDb != null)
            {
                await _connection.DeleteAsync(contactInDb);
            }
        }
    }
}
