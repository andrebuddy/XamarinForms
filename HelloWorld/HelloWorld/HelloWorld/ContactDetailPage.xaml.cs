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
        public event EventHandler<ContactBook> ContactAdded;
        public event EventHandler<ContactBook> ContactUpdated;

        public ContactDetailPage(ContactBook contact = null)
        {
            InitializeComponent();

            BindingContext = contact;
        }

        //TODO PLEASE ENTER THE NAME
        public void Save_Contact(object sender, EventArgs e)
        {
            var contact = BindingContext as ContactBook;

            if (contact.Id == 0)
                ContactAdded.Invoke(sender, contact);
            else
                ContactUpdated.Invoke(sender, contact);
        }
    }
}




















