using Xamarin.Forms;

namespace Resources
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Code behind
            //this.Resources = new ResourceDictionary();
            //this.Resources["borderRadius"] = 20;
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Resources["buttonBackgroundColor"] = Color.Blue;
        }
    }
}
