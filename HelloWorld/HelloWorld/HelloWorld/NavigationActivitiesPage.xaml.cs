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
    public partial class NavigationActivitiesPage : ContentPage
    {
        private ActivityService _service;
        public NavigationActivitiesPage()
        {
            _service = new ActivityService();

            InitializeComponent();
            PopulateListView();
        }

        private void PopulateListView()
        {
            listView.ItemsSource = _service.GetActivities();
        }

        private async void OnActivitySelected(object sender, SelectedItemChangedEventArgs e)
        {
            var activity = e.SelectedItem as Activity;

            await Navigation.PushAsync(new NavigationActivityProfilePage(activity.UserId));
        }
    }
}