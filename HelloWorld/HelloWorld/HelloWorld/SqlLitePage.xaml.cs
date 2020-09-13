using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    //[Table("Recipes")]
    public class Recipe : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]//[Column("RecipeId")]
        public int Id { get; set; }

        private string _name;

        [MaxLength(255)]
        public string Name { 
            get { return _name; }
            set 
            {
                if (_name == value)
                    return;

                _name = value;

                OnPropertyChanged();
            }
        }

        // CallerMemberName == nameof(Name)
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SqlLitePage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes; 

        public SqlLitePage()
        {
            InitializeComponent();

            // create connection
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            // if we already have table, its not problem
            await _connection.CreateTableAsync<Recipe>();

            // get all recipes
            var recipesFromDb = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipesFromDb);

            // populate list view
            recipesListView.ItemsSource = _recipes;

            base.OnAppearing();
        }

        async void OnAdd(object sender, System.EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };
            await _connection.InsertAsync(recipe);
            _recipes.Add(recipe);
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {
            var recipeToUpdate = _recipes[0];
            recipeToUpdate.Name += " UPDATED";

            await _connection.UpdateAsync(recipeToUpdate);
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var recipeToDelete = _recipes[0];
            await _connection.DeleteAsync(recipeToDelete);
            _recipes.Remove(recipeToDelete);
        }
    }
}