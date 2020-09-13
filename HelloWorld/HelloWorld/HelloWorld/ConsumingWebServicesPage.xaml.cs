using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
	public class Post
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
	}

	public partial class ConsumingWebServicesPage : ContentPage
	{
		private const string Url = "https://jsonplaceholder.typicode.com/posts";
		private HttpClient _client = new HttpClient();
		private ObservableCollection<Post> _posts;

		public ConsumingWebServicesPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			var content = await _client.GetStringAsync(Url);
			var posts = JsonConvert.DeserializeObject<List<Post>>(content);
			_posts = new ObservableCollection<Post>(posts);

			postsListView.ItemsSource = _posts;

			base.OnAppearing();
		}

		async void OnAdd(object sender, System.EventArgs e)
		{
			var post = new Post { Title = "Title " + DateTime.Now.Ticks };

			// optimistic update
			//_posts.Insert(0, post);

			// do post and get result
			var json = JsonConvert.SerializeObject(post);
			var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(Url, data);

			if (!response.IsSuccessStatusCode)
				return;

            var result = response.Content.ReadAsStringAsync().Result;

			post = JsonConvert.DeserializeObject<Post>(result);
			_posts.Insert(0, post);
        }

		async void OnUpdate(object sender, System.EventArgs e)
		{
			var post = _posts[0];
			post.Title = "Updated " + post.Title;

			var json = JsonConvert.SerializeObject(post);
			var data = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _client.PutAsync(Url + "/" + post.Id, data);

			if (!response.IsSuccessStatusCode)
				return;

			var result = response.Content.ReadAsStringAsync().Result;

			post = JsonConvert.DeserializeObject<Post>(result);
			_posts[0] = post;
		}

		async void OnDelete(object sender, System.EventArgs e)
		{
			var post = _posts[0];

			await _client.DeleteAsync(Url + "/" + post.Id);

			_posts.Remove(post);
		}
	}
}