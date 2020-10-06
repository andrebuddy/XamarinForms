using HelloWorld.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public class MovieService
    {
        private const string Url = "https://www.omdbapi.com/?";
        private const string ApiKey = "43ff5957";

        public static readonly int MinSearchLength = 5;

        private HttpClient _client;

        public MovieService()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<Movie>> FindByTitle(string title)
        {
            if (title.Length < MinSearchLength)
                return Enumerable.Empty<Movie>();

            var url = $"{Url}s={title}&apikey={ApiKey}";
            var response = await _client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return Enumerable.Empty<Movie>();

            var content = await response.Content.ReadAsStringAsync();
            var omdb = JsonConvert.DeserializeObject<Omdb>(content);

            return omdb.Movies ?? Enumerable.Empty<Movie>();
        }

        public async Task<Movie> FindById(string id)
        {
            var url = $"{Url}i={id}&apikey={ApiKey}";
            var response = await _client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Movie>(content);
        }
    }
}
