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
    public partial class ListPage : ContentPage
    {
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
            listView.ItemsSource = new List<Contact>
            {
                new Contact { Name = "Mosh", ImageUrl = "https://images.pexels.com/photos/2422278/pexels-photo-2422278.jpeg" },
                new Contact { Name = "Joana", ImageUrl = "https://images.pexels.com/photos/3765175/pexels-photo-3765175.jpeg", Status = "Hey lets talk!" }
            };
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
    }
}