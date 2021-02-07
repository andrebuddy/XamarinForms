using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    /*
     * This is a Plain Old CLR Objects
     * No references to Xamarin
     */
    public class PlaylistsViewModel : BaseViewModel
    {
        // private fields
        private PlaylistViewModel _selectedPlaylist;
        private string _title;
        private readonly IPageService _pageService;

        // all public properties that represent public interface this view model
        public ObservableCollection<PlaylistViewModel> Playlists { get; private set; } = new ObservableCollection<PlaylistViewModel>();

        public PlaylistViewModel SelectedPlaylist
        {
            get { return _selectedPlaylist; }
            set { SetValue(ref _selectedPlaylist, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetValue(ref _title, value); }
        }

        public ICommand AddPlaylistCommand { get; private set; }
        public ICommand SelectPlaylistCommand { get; private set; }

        public PlaylistsViewModel(IPageService pageService)
        {
            _pageService = pageService;

            // quando usamos nome metodo sem parentesis, representa uma acao
            AddPlaylistCommand = new Command(AddPlaylist);
            SelectPlaylistCommand = new Command<PlaylistViewModel>(async vm => await SelectPlaylist(vm));
        }

        private void AddPlaylist()
        {
            var newPlaylist = "Playlist " + (Playlists.Count + 1);

            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });

            UpdateTitle();
        }

        private async Task SelectPlaylist(PlaylistViewModel selectedPlaylist)
        {
            if (selectedPlaylist == null)
                return;

            selectedPlaylist.IsFavorite = !selectedPlaylist.IsFavorite;

            SelectedPlaylist = null;

            await _pageService.PushAsync(new PlaylistDetailPage(selectedPlaylist));
        }

        private void UpdateTitle()
        {
            Title = $"{Playlists.Count} Playlists";
        }
    }
}
