using HelloWorld.Models;
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
            BindingContext = new PlaylistViewModel();

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void OnAddPlaylist(object sender, System.EventArgs e)
        {
            (BindingContext as PlaylistViewModel).AddPlaylist();
        }

        private void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as PlaylistViewModel).SelectPlaylist(e.SelectedItem as Playlist);
        }
    }
}