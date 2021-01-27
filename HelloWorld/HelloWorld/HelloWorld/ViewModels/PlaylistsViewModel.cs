using System.Collections.ObjectModel;

namespace HelloWorld.ViewModels
{
    /*
     * This is a Plain Old CLR Objects
     * No references to Xamarin
     */
    public class PlaylistsViewModel : BaseViewModel
    {
        public ObservableCollection<PlaylistViewModel> Playlists { get; private set; } = new ObservableCollection<PlaylistViewModel>();

        private PlaylistViewModel _selectedPlaylist;
        public PlaylistViewModel SelectedPlaylist
        {
            get { return _selectedPlaylist; }
            set { SetValue(ref _selectedPlaylist, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetValue(ref _title, value); }
        }

        public void AddPlaylist()
        {
            var newPlaylist = "Playlist " + (Playlists.Count + 1);

            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });

            UpdateTitle();
        }

        public void SelectPlaylist(PlaylistViewModel selectedPlaylist)
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
