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

        }

        private void Select_Contact(object sender, ItemTappedEventArgs e)
        {

        }
    }
}