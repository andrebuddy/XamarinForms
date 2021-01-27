using HelloWorld.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistPage : ContentPage
    {
        public PlaylistPage()
        {
            ViewModel = new PlaylistsViewModel(new PageService());

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            // ViewModel.LoadPlaylistCommand.Execute();
            base.OnAppearing();
        }

        private void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectPlaylistCommand.Execute(e.SelectedItem as PlaylistViewModel);
        }

        public PlaylistsViewModel ViewModel
        {
            get { return BindingContext as PlaylistsViewModel; }
            set { BindingContext = value; }
        }
    }
}