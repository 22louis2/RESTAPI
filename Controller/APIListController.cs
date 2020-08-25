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
        public static async Task GetAPIDetailsToList(int pageNumber)
        {

            for (int i = 0; i < pageNumber; i++)
            {
                var users = APIController.GetDetailsFromAPI(i + 1);
                var endPoints = await users;
                DB.User.AddRange(endPoints.data.ToList());
            }
        }
    }
}
