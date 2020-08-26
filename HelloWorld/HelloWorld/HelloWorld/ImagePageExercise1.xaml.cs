using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePageExercise1 : ContentPage
    {
        private int _index = 0;
        private readonly string[] _imagesUriArray = {
            "https://images.unsplash.com/photo-1508138221679-760a23a2285b?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=967&q=80",
            "https://images.unsplash.com/photo-1489533119213-66a5cd877091?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1051&q=80",
            "https://images.unsplash.com/photo-1487088678257-3a541e6e3922?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=967&q=80",
            "https://images.unsplash.com/photo-1519125323398-675f0ddb6308?ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80",
            "https://images.unsplash.com/photo-1494253109108-2e30c049369b?ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80"
        };

        public ImagePageExercise1()
        {
            InitializeComponent();

            SetImageInternet(_imagesUriArray[_index]);
        }

        private void SetImageInternet(string uriString)
        {
            var imageSource = new UriImageSource
            {
                Uri = new Uri(uriString)
            };

            imageSource.CachingEnabled = false;
            imageSource.CacheValidity = TimeSpan.FromHours(1);

            photo.Source = imageSource;
        }

        private void Left_Clicked(object sender, EventArgs e)
        {
            _index--;
            if (_index < 0) _index = _imagesUriArray.Length - 1;

            SetImageInternet(_imagesUriArray[_index]);
        }

        private void Right_Clicked(object sender, EventArgs e)
        {
            _index++;
            if (_index >= _imagesUriArray.Length) _index = 0;

            SetImageInternet(_imagesUriArray[_index]);
        }
    }
}