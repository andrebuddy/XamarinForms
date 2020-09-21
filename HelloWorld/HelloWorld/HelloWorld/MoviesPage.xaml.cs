using HelloWorld.Models;
using HelloWorld.Services;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        private MoviesService _service = new MoviesService();
        private ObservableCollection<Movie> _movies;

        public MoviesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            cancelButton.IsVisible = true;
            moviesListView.IsVisible = false;

            var movies = await _service.FindMoviesByTitle("andre");
            _movies = new ObservableCollection<Movie>(movies);

            moviesListView.ItemsSource = _movies;

            moviesListView.IsVisible = true;
            cancelButton.IsVisible = false;

            base.OnAppearing();
        }

        private async void OnFilterMovie(object sender, TextChangedEventArgs movieName)
        {
            if (movieName.NewTextValue.Length < 5)
                return;

            cancelButton.IsVisible = true;
            moviesListView.IsVisible = false;

            var movies = await _service.FindMoviesByTitle(movieName.NewTextValue);

            if (movies == null)
                await DisplayAlert("Error", "No movies found matching your search", "OK");

            _movies = new ObservableCollection<Movie>(movies);

            moviesListView.ItemsSource = _movies;

            moviesListView.IsVisible = true;
            cancelButton.IsVisible = false;
        }

        private async void OnSelectMovie(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMovie = e.SelectedItem as Movie;

            var moviee = await _service.FindMovie(selectedMovie.ImdbId);

            await Navigation.PushAsync(new MoviesDetailPage(moviee));

        }

        private void OnCancel(object sender, System.EventArgs e)
        {

        }
    }
}