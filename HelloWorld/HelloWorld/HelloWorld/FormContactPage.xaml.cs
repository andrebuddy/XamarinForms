using HelloWorld.Models;
using HelloWorld.Services;
using System;
using System.Collections.Generic;
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
        private ContactService _service = new ContactService();

        public FormContactPage()
        {
            InitializeComponent();
            PopulateListView();
        }

        private void PopulateListView()
        {
            listView.ItemsSource = _service.GetContacts();
            //BindingContext = _service.GetContacts();
        }

        private async void OnAddContact(object sender, EventArgs e)
        {
            var page = new ContactDetailPage(new ContactBook());

            page.AddContactHandler += (source, contact) =>
            {
                _service.AddContact(contact);
            };

            await Navigation.PushAsync(new ContactDetailPage(new ContactBook()));
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

            page.UpdateContactHandler += (source, contact) =>
            {
                _service.UpdateContact(contact.Id, contact);
            };

            await Navigation.PushAsync(page);
        }

        private void OnContactDeleted(object sender, EventArgs e)
        {
            var contactToDelete = (sender as MenuItem).CommandParameter as ContactBook;
            _service.DeleteContact(contactToDelete.Id);
        }
    }
}