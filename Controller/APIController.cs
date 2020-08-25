using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using REST_API.Model;

namespace REST_API.Controller
{
    public class APIController
    {
        public static int TotalPages { get; set; } = 0;
        public static async Task<Article> GetDetailsFromAPI(int page)
        {
            string getUrl = $"https://jsonmock.hackerrank.com/api/article_users/search?page={page}";
           
            using (HttpClient httpclient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpclient.GetAsync(getUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var pageDetails = JsonSerializer.Deserialize<Article>(json);
                        TotalPages = pageDetails.total_pages;
                        return pageDetails;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            } 
        }
    }
}
