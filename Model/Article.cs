using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace REST_API.Model
{
    public class Article
    {
        public string page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public User[] data { get; set; }
    }
}
