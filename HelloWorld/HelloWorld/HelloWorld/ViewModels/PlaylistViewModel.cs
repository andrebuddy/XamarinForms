using HelloWorld.Models;
using System.Collections.ObjectModel;

namespace HelloWorld.ViewModels
{
    /*
     * This is a Plain Old CLR Objects
     * No references to Xamarin
     */
    public class PlaylistViewModel
    {
        public ObservableCollection<Playlist> Playlists { get; private set; } = new ObservableCollection<Playlist>();
        public Playlist SelectedPlaylist { get; set; }
        public string Title { get; private set; } = "0 Playlists";

        public void AddPlaylist()
        {
            var newPlaylist = "Playlist " + (Playlists.Count + 1);

            Playlists.Add(new Playlist { Title = newPlaylist });

            UpdateTitle();
        }

        public void SelectPlaylist(Playlist selectedPlaylist)
        {
            if (selectedPlaylist == null)
                return;

            selectedPlaylist.IsFavorite = !selectedPlaylist.IsFavorite;

            SelectedPlaylist = null;
        }

        private void UpdateTitle()
        {
            Title = $"{Playlists.Count} Playlists";
        }
    }
}
