using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace REST_API.Model
{
    public class User
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("about")]
        public string About { get; set; }
        [JsonPropertyName("submitted")]
        public int Submitted { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonPropertyName("submission_count")]
        public int SubmissionCount { get; set; }
        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; }
        [JsonPropertyName("created_at")]
        public int CreatedAt { get; set; }
    }
}

