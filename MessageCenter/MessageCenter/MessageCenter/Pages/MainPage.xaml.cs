using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessageCenter.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            var page = new TargetPage();
            page.SliderValueChanged += OnSliderValueChanged;

            Navigation.PushAsync(page);
        }

        private void OnSliderValueChanged(object source, double newValue)
        {
            label.Text = newValue.ToString();
        }
    }
}