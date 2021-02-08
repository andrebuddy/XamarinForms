using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessageCenter.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private const string EventName = "SliderValueChanged";

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            var page = new TargetPage();
            //page.SliderValueChanged += OnSliderValueChanged;

            // here we are subscribing to the event
            MessagingCenter.Subscribe<TargetPage, double>(this, EventName, OnSliderValueChanged);

            Navigation.PushAsync(page);
        }

        private void OnSliderValueChanged(object source, double newValue)
        {
            label.Text = newValue.ToString();
        }
    }
}