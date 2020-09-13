using HelloWorld.Models;
using HelloWorld.Repository;
using HelloWorld.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormContactPage : ContentPage
    {
        private ContactService _service = new ContactService(new ContactRepository());
        private ObservableCollection<ContactBook> _contacts;

        public FormContactPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var contacts = await _service.GetContacts();
            _contacts = new ObservableCollection<ContactBook>(contacts);
            listView.ItemsSource = _contacts;

            base.OnAppearing();
        }

        private async void OnAddContact(object sender, EventArgs e)
        {
            var page = new ContactDetailPage(new ContactBook());

            page.AddContactHandler += async (source, contact) =>
            {
                await _service.AddContact(contact);
            };

            await Navigation.PushAsync(page);
        }

        private async void OnContactSelected(object sender, ItemTappedEventArgs e)
        {
            // We need to check if SelectedItem is null because further below 
            // we de-select the selected item. This will raise another ItemSelected
            // event, so this method will be called straight away. If we don't
            // check for null here, we'll get a NullReferenceException.
            if (listView.SelectedItem == null)
                return;

            var selectedContact = e.Item as ContactBook;

            // We de-select the selected item, so when we come back to the Contacts
            // page we can tap it again and navigate to ContactDetail. 
            listView.SelectedItem = null;

            var page = new ContactDetailPage(selectedContact);

            page.UpdateContactHandler += async (source, contact) =>
            {
                var updated = await _service.UpdateContact(contact);
                if (updated)
                {
                    selectedContact.Id = contact.Id;
                    selectedContact.FirstName = contact.FirstName;
                    selectedContact.LastName = contact.LastName;
                    selectedContact.Phone = contact.Phone;
                    selectedContact.Email = contact.Email;
                    selectedContact.Blocked = contact.Blocked;
                }
            };

            await Navigation.PushAsync(page);
        }

        private async void OnContactDeleted(object sender, EventArgs e)
        {
            var contactToDelete = (sender as MenuItem).CommandParameter as ContactBook;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contactToDelete.FirstName}?", "Yes", "No"))
            {
                var deleted = await _service.DeleteContact(contactToDelete);
                if (deleted)
                {
                    _contacts.Remove(contactToDelete);
                }
            }
        }
    }
}