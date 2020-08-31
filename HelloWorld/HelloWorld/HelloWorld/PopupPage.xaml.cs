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
    public partial class PopupPage : ContentPage
    {
        public PopupPage()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            //Confirmation Box
            var title = "Warning";
            var message = "Are you sure?";
            var acceptTitle = "Yes";
            var cancelTitle = "No";

            var response = await DisplayAlert(title, message, acceptTitle, cancelTitle);

            if (response)
                await DisplayAlert("Done", "Your response will be saved!", "OK");
        }

        async private void Button_Clicked2(object sender, EventArgs e)
        {
            //Confirmation Box
            var title = "Warning";
            var cancelLabel = "Cancel";
            var deleteLabel = "Delete";
            string[] buttons = {
                "Copy link",
                "Message",
                "Email"
            };

            var response = await DisplayActionSheet(title, cancelLabel, deleteLabel, buttons);
            await DisplayAlert("Response", response, "OK");
        }
    }
}