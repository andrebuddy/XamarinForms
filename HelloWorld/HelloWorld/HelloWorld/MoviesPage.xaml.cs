using HelloWorld.Models;
using HelloWorld.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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

        private BindableProperty IsSearchingProperty =
            BindableProperty.Create("IsSearching", typeof(bool), typeof(MoviesPage), false);
        public bool IsSearching
        {
            get { return (bool)GetValue(IsSearchingProperty); }
            set { SetValue(IsSearchingProperty, value); }
        }

        public MoviesPage()
        {
            BindingContext = this;

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

            await FindMovies(title: e.NewTextValue);
        }

        private async Task FindMovies(string title)
        {
            try
            {
                IsSearching = true;

                var movies = await _service.FindByTitle(title);

                if (!movies.Any())
                    await DisplayAlert("Error", "No movies found matching your search", "OK");

                _movies = new ObservableCollection<Movie>(movies);

                moviesListView.ItemsSource = _movies;
                moviesListView.IsVisible = _movies.Any();
                notFound.IsVisible = !moviesListView.IsVisible;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Could not retrieve the list of movies", "OK");
            }
            finally
            {
                IsSearching = false;
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