using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;

namespace REST_API.Model
{
    public class Article
    {
        [JsonPropertyName("page")]
        public string Page { get; set; }
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("data")]
        public User[] Data { get; set; }
    }
}
