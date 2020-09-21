using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    public class OmDbApi
    {
        [JsonProperty("Search")]
        public List<Movie> Movies { get; set; }

        [JsonProperty("totalResults")]
        public string Total { get; set; }

        [JsonProperty("Response")]
        public bool Response { get; set; }
    }
}
