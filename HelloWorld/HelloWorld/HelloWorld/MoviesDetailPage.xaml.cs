using HelloWorld.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesDetailPage : ContentPage
    {
        public MoviesDetailPage(Movie movie)
        {
            InitializeComponent();

            BindingContext = movie;
        }


    }
}