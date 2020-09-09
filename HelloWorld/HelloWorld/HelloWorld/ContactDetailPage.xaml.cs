using HelloWorld.Models;
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
    public partial class ContactDetailPage : ContentPage
    {
        //Events
        public event EventHandler<ContactBook> AddContactHandler;
        public event EventHandler<ContactBook> UpdateContactHandler;

        public ContactDetailPage(ContactBook contact = null)
        {
            InitializeComponent();

            BindingContext = contact;
        }

        private async void OnSave(object sender, EventArgs e)
        {
            var contact = BindingContext as ContactBook;

            if (string.IsNullOrEmpty(contact.FirstName) || string.IsNullOrEmpty(contact.LastName))
            {
                await DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if (contact.Id == 0)
                AddContactHandler.Invoke(sender, contact);
            else
                UpdateContactHandler.Invoke(sender, contact);

            await Navigation.PopAsync();
        }
    }
}




















