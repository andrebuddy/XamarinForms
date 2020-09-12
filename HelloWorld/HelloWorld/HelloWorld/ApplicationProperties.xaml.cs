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
    public partial class ApplicationProperties : ContentPage
    {
        public ApplicationProperties()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("Name"))
                title.Text = Application.Current.Properties["Name"].ToString();

            if (Application.Current.Properties.ContainsKey("NotificationsEnabled"))
                notificationsEnabled.On = (bool) Application.Current.Properties["NotificationsEnabled"];
        }

        //standard event handler, 
        //we can use this for handler of all king events
        private void OnChanged(object sender, System.EventArgs e)
        {
            // Persistence happens when app goes sleep mode
            // when we open another app, so this one goes background and another foreground
            // when we quit app
            Application.Current.Properties["Name"] = title.Text;
            Application.Current.Properties["NotificationsEnabled"] = notificationsEnabled.On;

            // we dont need wait
            //Application.Current.SavePropertiesAsync();
        }

        // when we navigate away from this screen
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }


    }
}