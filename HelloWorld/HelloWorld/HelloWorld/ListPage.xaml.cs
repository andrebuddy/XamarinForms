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

            listView.ItemsSource = new List<Contact>
            {
                new Contact { Name = "Mosh", ImageUrl = "https://images.pexels.com/photos/2422278/pexels-photo-2422278.jpeg" },
                new Contact { Name = "Joana", ImageUrl = "https://images.pexels.com/photos/3765175/pexels-photo-3765175.jpeg", Status = "Hey lets talk!" }
            };
        }
    }
}