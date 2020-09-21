using HelloWorld.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld.Services
{
    public class MoviesService
    {
        private string _url = "https://www.omdbapi.com/?";
        private string _apiKey = "apikey=43ff5957";
        private HttpClient _client;

        public MoviesService()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<Movie>> FindMoviesByTitle(string title)
        {
            var url = new StringBuilder(_url)
                .Append("s=")
                .Append(title)
                .Append("&")
                .Append(_apiKey)
                .ToString();

            var response = await _client.GetAsync(url);

            Thread.Sleep(1000);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var omdb = JsonConvert.DeserializeObject<OmDbApi>(content);

            return omdb.Response ? omdb.Movies : new List<Movie>();
        }

        public async Task<Movie> FindMovie(string imdbId)
        {
            var url = new StringBuilder(_url)
               .Append("i=")
               .Append(imdbId)
               .Append("&")
               .Append(_apiKey)
               .ToString();

            var response = await _client.GetAsync(url);

            Thread.Sleep(1000);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Movie>(content);
        }
    }
}
