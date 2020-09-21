using Newtonsoft.Json;

namespace HelloWorld.Models
{
    public class Movie
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }
        [JsonProperty("Genre")]
        public string Genre { get; set; }
        [JsonProperty("Plot")]
        public string Plot { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbId { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }


        [JsonProperty("Poster")]
        public string Poster { get; set; }
    }
}
