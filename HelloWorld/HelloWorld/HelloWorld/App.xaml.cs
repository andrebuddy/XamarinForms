using Xamarin.Forms;

namespace HelloWorld
{
    public partial class App : Application
    {
        private const string TitleKey = "Name";
        private const string NotificationsEnableKey = "NotificationsEnable";

        public string Title
        {
            get
            {
                if (Properties.ContainsKey(TitleKey))
                    return Properties[TitleKey].ToString();

                return string.Empty;
            }
            set => Properties[TitleKey] = value;
        }

        public bool NotificationsEnable
        {
            get
            {
                if (Properties.ContainsKey(NotificationsEnableKey))
                    return (bool)Properties[NotificationsEnableKey];

                return false;
            }
            set
            {
                Properties[NotificationsEnableKey] = value;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new ContactsPage())
            //{
            //    BarBackgroundColor = Color.Chocolate,
            //    BarTextColor = Color.White
            //};

            MainPage = new NavigationPage(new PlaylistPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
