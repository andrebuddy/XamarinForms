using HelloWorld.Models;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistPage : ContentPage
    {
        private ObservableCollection<Playlist> _playlists = new ObservableCollection<Playlist>();
        public PlaylistPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            playlistView.ItemsSource = _playlists;

            base.OnAppearing();
        }

        private void OnAddPlaylist(object sender, System.EventArgs e)
        {
            var newPlaylist = "Playlist " + (_playlists.Count + 1);

            _playlists.Add(new Playlist { Title = newPlaylist });

            this.Title = $"{_playlists.Count} Playlist";
        }

        private void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var playlist = e.SelectedItem as Playlist;
            playlist.IsFavorite = !playlist.IsFavorite;

            playlistView.SelectedItem = null;
        }
    }
}