
using ContactBook.Models;
using ContactBook.Persistence;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;

        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;

        public ContactDetailPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            BindingContext = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked
            };
        }

        private async void OnSave(object sender, EventArgs e)
        {
            var contact = BindingContext as Contact;

            if (string.IsNullOrEmpty(contact.FullName))
            {
                await DisplayAlert("Error", "Please enter the name", "OK");
                return;
            }

            if (contact.Id == 0)
            {
                await _connection.InsertAsync(contact);
                ContactAdded?.Invoke(this, contact);
            }
            else
            {
                await _connection.UpdateAsync(contact);
                ContactUpdated?.Invoke(this, contact);
            }

            await Navigation.PopAsync();
        }
    }
}