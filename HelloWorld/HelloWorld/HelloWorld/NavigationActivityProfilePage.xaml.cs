using HelloWorld.Models;
using HelloWorld.Services;
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
    public partial class NavigationActivityProfilePage : ContentPage
    {
        private UserService _service = new UserService();

        public NavigationActivityProfilePage(int userId)
        {
            InitializeComponent();

            BindingContext = _service.GetUser(userId);
        }
    }
}