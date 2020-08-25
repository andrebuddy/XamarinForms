using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        [Obsolete]
        public ImagePage()
        {
            InitializeComponent();
        }

        private void setImagePlatformSpecific()
        {
            //btn.ImageSource = (FileImageSource)ImageSource.FromFile(Device.OnPlatform(
            //    iOS: "clock.png",
            //    Android: "clock.png",
            //    WinPhone: "Images/clock.png"));
        }

        private void SetImageResource()
        {
            //ApplicationName.Folder/foldersName.ImageNameWithExtension
            //image.Source = ImageSource.FromResource("HelloWorld.Images.background.jpg");
        }

        private void SetImageInternet()
        {
            var uriString = "https://www.denhaag.nl/upload/83b69004-d2d2-4e4d-a999-6169e576208e_Zwemmer.jpg";

            var imageSource = new UriImageSource
            {
                Uri = new Uri(uriString)
            };
            //imageSource.CachingEnabled = true;
            //imageSource.CacheValidity = TimeSpan.FromHours(1);

            //image.Source = imageSource;
        }

        private void SetImageAlternatives()
        {
            //image.Source = uriString;
            //var imageSource = (UriImageSource) ImageSource.FromUri(new Uri(uriString));
        }
    }
}