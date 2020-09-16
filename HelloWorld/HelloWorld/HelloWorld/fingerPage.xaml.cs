using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
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
    public partial class fingerPage : ContentPage
    {
        public fingerPage()
        {
            InitializeComponent();

            
        }

        protected override async void OnAppearing()
        {
            var request = new AuthenticationRequestConfiguration("Prove you have fingers!", "Because without it you can't have access");
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);
            if (result.Authenticated)
            {
                // do secret stuff :)
                await DisplayAlert("title", "yes", "ok");
            }
            else
            {
                // not allowed to do secret stuff :(
                await DisplayAlert("title", "no", "ok");

            }

            base.OnAppearing();
        }
    }
}