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
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();

            var uriString = "https://www.denhaag.nl/upload/83b69004-d2d2-4e4d-a999-6169e576208e_Zwemmer.jpg";
            //image.Source = uriString;
            //var imageSource = (UriImageSource) ImageSource.FromUri(new Uri(uriString));

            var imageSource = new UriImageSource
            {
                Uri = new Uri(uriString)
            };
            imageSource.CachingEnabled = false;
            imageSource.CacheValidity = TimeSpan.FromHours(1);

            image.Source = imageSource;

        }
    }
}