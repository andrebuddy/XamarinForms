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

        //Grouping Items
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

        //Customs Cells
        private void setViewCell()
        {
            _contacts = new ObservableCollection<Contact>
            {
                new Contact { Name = "Mosh", ImageUrl = "https://images.pexels.com/photos/2422278/pexels-photo-2422278.jpeg" },
                new Contact { Name = "Joana", ImageUrl = "https://images.pexels.com/photos/3765175/pexels-photo-3765175.jpeg", Status = "Hey lets talk!" }
            };

            listView.ItemsSource = _contacts;
        }

        private IEnumerable<Contact> GetContacts(string searchText = null)
        {
            var contacts = new List<Contact>
            {
                new Contact { Name = "Mosh", ImageUrl = "https://images.pexels.com/photos/2422278/pexels-photo-2422278.jpeg" },
                new Contact { Name = "Joana", ImageUrl = "https://images.pexels.com/photos/3765175/pexels-photo-3765175.jpeg", Status = "Hey lets talk!" }
            };

            if (string.IsNullOrEmpty(searchText))
                return contacts;

            return contacts.Where(c => c.Name.ToLower().StartsWith(searchText.ToLower()));
        }

        //Handeling Selections - Primeiro chamado
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as Contact;
            DisplayAlert("Selected", contact.Name, "OK");

            //desactivar selecao
            //listView.SelectedItem = null;
        }

        //Handeling Selections - Segundo e proximas chamadas
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            DisplayAlert("Tapped", contact.Name, "OK");
        }

        //Context Actions
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

        //Pull to Refresh
        private void listView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = GetContacts();

            listView.EndRefresh();
        }

        //Search Bar
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetContacts(e.NewTextValue); 
        }
    }
}