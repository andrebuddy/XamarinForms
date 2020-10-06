using HelloWorld.Models;
using HelloWorld.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesDetailPage : ContentPage
    {
        private MovieService _service = new MovieService();
        private Movie _movie;
        public MoviesDetailPage(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movie = movie;

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            BindingContext = await _service.FindById(id: _movie.ImdbId);

            base.OnAppearing();
        }
    }
}