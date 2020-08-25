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

            //ApplicationName.Folder/foldersName.ImageNameWithExtension
            image.Source = ImageSource.FromResource("HelloWorld.Images.background.jpg");
        }

        private void setImageInternet()
        {
            var uriString = "https://www.denhaag.nl/upload/83b69004-d2d2-4e4d-a999-6169e576208e_Zwemmer.jpg";

            var imageSource = new UriImageSource
            {
                Uri = new Uri(uriString)
            };
            //imageSource.CachingEnabled = true;
            //imageSource.CacheValidity = TimeSpan.FromHours(1);

            image.Source = imageSource;
        }

        private void setImageAlternatives()
        {
            //image.Source = uriString;
            //var imageSource = (UriImageSource) ImageSource.FromUri(new Uri(uriString));
        }
    }
}