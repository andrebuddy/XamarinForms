using ContactBook.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(ContactDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}