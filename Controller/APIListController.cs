using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REST_API.Model;

namespace REST_API.Controller
{
    public class APIListController
    {
        /*
         * Method To Loop Through the Number of Pages Available using the 
         * API Get Request method and Task represents an asynchronous operation
         * Task class represents a single operation that does not return a value
        */
        public static async Task GetAPIDetailsList(int pageNumber)
        {

            for (int i = 0; i < pageNumber; i++)
            {
                // Call the API GET Request method from the APIController Class
                var users = APIController.GetDetailsFromAPI(i + 1);
                // Asynchronously waiting for the HTTP response
                var endPoints = await users;
                // Add the collection of endpoints to the end of the User Data Array
                DB.User.AddRange(endPoints.Data.ToList());
            }
        }
    }
}
