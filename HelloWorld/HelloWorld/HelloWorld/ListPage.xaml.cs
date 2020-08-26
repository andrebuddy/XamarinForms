using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts;

        public ListPage()
        {

            InitializeComponent();

            setViewCell();
            //setGroupCell();
        }

        private void setGroupCell()
        {
            listView.ItemsSource = new List<ContactGroup>
            {
                new ContactGroup ("M", "Instructor")
                {
                    new Contact { Name = "Mosh", ImageUrl = "https://images.pexels.com/photos/2422278/pexels-photo-2422278.jpeg" },
                },
                new ContactGroup ("J", "Family")
                {
                    new Contact { Name = "Joana", ImageUrl = "https://images.pexels.com/photos/3765175/pexels-photo-3765175.jpeg", Status = "Hey lets talk!" },
                    new Contact { Name = "Antonio", ImageUrl = "https://images.pexels.com/photos/3765175/pexels-photo-3765175.jpeg", Status = "Bofia" }
                }
            };
        }

        private void setViewCell()
        {
            _contacts = new ObservableCollection<Contact>
            {
                new Contact { Name = "Mosh", ImageUrl = "https://images.pexels.com/photos/2422278/pexels-photo-2422278.jpeg" },
                new Contact { Name = "Joana", ImageUrl = "https://images.pexels.com/photos/3765175/pexels-photo-3765175.jpeg", Status = "Hey lets talk!" }
            };

            listView.ItemsSource = _contacts;
        }

        //Primeiro chamado
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as Contact;
            DisplayAlert("Selected", contact.Name, "OK");

            //desactivar selecao
            //listView.SelectedItem = null;
        }

        //Segundo e proximas chamadas
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            DisplayAlert("Tapped", contact.Name, "OK");
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;

            DisplayAlert("Call", contact.Name, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            _contacts.Remove(contact);
        }

        private List<Contact> GetContacts()
        {
            return new List<Contact>
            {
                new Contact { Name = "Mosh", ImageUrl = "https://images.pexels.com/photos/2422278/pexels-photo-2422278.jpeg" },
                new Contact { Name = "Joana", ImageUrl = "https://images.pexels.com/photos/3765175/pexels-photo-3765175.jpeg", Status = "Hey lets talk!" }
            };
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = GetContacts();

            listView.EndRefresh();
        }
    }
}