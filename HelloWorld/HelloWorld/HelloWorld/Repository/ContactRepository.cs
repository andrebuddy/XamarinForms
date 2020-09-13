using HelloWorld.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld.Repository
{
    public class ContactRepository : IRepository<ContactBook>
    {
        private SQLiteAsyncConnection _connection;

        public ContactRepository()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            Init();
        }

        private async void Init()
        {
            await _connection.CreateTableAsync<ContactBook>();
        }

        public async Task<int> Create(ContactBook contactBook)
        {
            return await _connection.InsertAsync(contactBook);
        }

        public async Task<int> Delete(ContactBook contact)
        {
            return await _connection.DeleteAsync(contact);
        }

        public async Task<List<ContactBook>> Read()
        {
            return await _connection.Table<ContactBook>().ToListAsync();
        }

        public async Task<int> Update(ContactBook contactBook)
        {
            return await _connection.UpdateAsync(contactBook);
        }
    }
}
