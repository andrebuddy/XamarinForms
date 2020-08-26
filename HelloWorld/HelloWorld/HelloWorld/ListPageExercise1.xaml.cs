using HelloWorld.Models;
using HelloWorld.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPageExercise1 : ContentPage
    {
        private SearchService _service;
        private ObservableCollection<SearchGroup> _searchGroups;

        public ListPageExercise1()
        {
            _service = new SearchService();

            InitializeComponent();

            PopulateListView(_service.GetSearches());
        }

        private void PopulateListView(IEnumerable<Search> searches)
        {
            _searchGroups = new ObservableCollection<SearchGroup>
            {
                new SearchGroup("Recent Searches", searches)
            };

            listView.ItemsSource = _searchGroups;
        }

        private void SearchBar_Filter(object sender, TextChangedEventArgs e)
        {
            PopulateListView(_service.GetSearches(e.NewTextValue));
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;
            DisplayAlert("Selected", search.Location, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var search = (sender as MenuItem).CommandParameter as Search;
            _service.DeleteSearch(search.Id);
            _searchGroups[0].Remove(search);
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            PopulateListView(_service.GetSearches(searchBar.Text));

            listView.EndRefresh();
        }
    }
}