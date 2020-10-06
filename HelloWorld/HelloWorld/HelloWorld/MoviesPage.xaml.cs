using HelloWorld.Models;
using HelloWorld.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        private MovieService _service = new MovieService();
        private ObservableCollection<Movie> _movies;

        public MoviesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await FindMovies(title: "andre");

            base.OnAppearing();
        }

        private async void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null || e.NewTextValue.Length < MovieService.MinSearchLength)
                return;

            await FindMovies(title: "andre");
        }

        private async Task FindMovies(string title)
        {
            try
            {
                cancelButton.IsVisible = true;
                moviesListView.IsVisible = false;

                var movies = await _service.FindByTitle(title);

                if (movies == null)
                    await DisplayAlert("Error", "No movies found matching your search", "OK");

                _movies = new ObservableCollection<Movie>(movies);

                moviesListView.ItemsSource = _movies;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Could not retrieve the list of movies", "OK");
            }
            finally
            {
                moviesListView.IsVisible = true;
                cancelButton.IsVisible = false;
            }
        }

        private async void OnMovieSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedMovie = e.SelectedItem as Movie;
            moviesListView.SelectedItem = null;

            await Navigation.PushAsync(new MoviesDetailPage(selectedMovie));
        }

        private void OnCancel(object sender, System.EventArgs e)
        {

        }
    }
}