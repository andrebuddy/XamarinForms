
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessageCenter.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TargetPage : ContentPage
    {
        private const string EventName = "SliderValueChanged";
        //public event EventHandler<double> SliderValueChanged;

        public TargetPage()
        {
            InitializeComponent();
        }

        private void OnSliderChanged(object sender, ValueChangedEventArgs e)
        {
            //SliderValueChanged?.Invoke(this, e.NewValue);
            MessagingCenter.Send(this, EventName, e.NewValue);
        }
    }
}