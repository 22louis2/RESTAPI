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
        // Property to get and set the Total Number of Pages retrieved from the API call 
        public static int TotalPages { get; set; } = 0;

        /*
         * Method for API Get Request and Task represents an asynchronous operation
         * Generic Task class represents a single operation that returns a value
        */
        public static async Task<Article> GetDetailsFromAPI(int page)
        {
            // URL to make API call to
            string getUrl = $"https://jsonmock.hackerrank.com/api/article_users/search?page={page}";

            // Using HttpClient to send request and receive response from HTTP
            using HttpClient httpclient = new HttpClient();
            /*
             * Getting the status code and data in the HTTP response message
             * After making the GET request to the URI
             * Using Asynchronous method 
            */
            using HttpResponseMessage response = await httpclient.GetAsync(getUrl);

            // Checking if the HTTP response was successful 
            if (response.IsSuccessStatusCode)
            {
                // Arrange the HTTP content as a string as an asynchronous operation
                var json = await response.Content.ReadAsStringAsync();
                /*
                 * Parse the deserialize JSON into objects or value types
                 * Which is in my Article Class
                */
                var pageDetails = JsonSerializer.Deserialize<Article>(json);
                /*
                 * Getting the Total Number of available pages from the object
                 * And pushing it to TotalPages property
                */
                TotalPages = pageDetails.TotalPages;
                // Returning my Deserialize JSON to object
                return pageDetails;
            }
            else
            {
                /*
                 * If the HTTP response is not successful, throw an error 
                 * With reason phrase status code.
                */
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
