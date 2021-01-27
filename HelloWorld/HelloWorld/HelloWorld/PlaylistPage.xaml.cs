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
            BindingContext = new PlaylistsViewModel(new PageService());

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void OnAddPlaylist(object sender, System.EventArgs e)
        {
            (BindingContext as PlaylistsViewModel).AddPlaylist();
        }

        private void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as PlaylistsViewModel).SelectPlaylist(e.SelectedItem as PlaylistViewModel);
        }
    }
}