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

            var app = Application.Current as App;

            title.Text = app.Title;
            notificationsEnabled.On = app.NotificationsEnable;
        }

        //standard event handler, 
        //we can use this for handler of all king events
        private void OnChanged(object sender, System.EventArgs e)
        {
            // Persistence happens when app goes sleep mode
            // when we open another app, so this one goes background and another foreground
            // when we quit app
            var app = Application.Current as App;
            app.Title = title.Text;
            app.NotificationsEnable = notificationsEnabled.On;

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