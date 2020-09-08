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

        private void Add_Contact(object sender, EventArgs e)
        {
            var page = new ContactDetailPage(new ContactBook());

            page.ContactAdded += (source, contact) =>
            {
                _service.AddContact(contact);
            };

            Navigation.PushAsync(new ContactDetailPage(new ContactBook()));
        }

        private async void Select_Contact(object sender, ItemTappedEventArgs e)
        {
            var contactSelected = e.Item as ContactBook;
            var page = new ContactDetailPage(contactSelected);

            page.ContactUpdated += (source, contact) =>
            {
                _service.UpdateContact(contact.Id, contact);
            };

            await Navigation.PushAsync(page);
        }

        private void Delete_Contact(object sender, EventArgs e)
        {
            var contactToDelete = (sender as MenuItem).CommandParameter as ContactBook;
            _service.DeleteContact(contactToDelete.Id);
        }
    }
}