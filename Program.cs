using REST_API.Controller;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using REST_API.Helper;

namespace REST_API
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Waiting, currently loading data");
            
            // API call, made the page number searches dynamic 
            int pageNumber = 1;
            do
            {
                await APIListController.GetAPIDetailsList(++pageNumber);
            }
            /*
             * Getting the total number of pages returned from the API call
             * Setting the number of pages to be searched on
             * Depending on the number of pages returned from the API call
            */
            while (pageNumber != APIController.TotalPages);

            #region START OF USER INTERFACE APPLICATION
            Console.WriteLine(@"
                -------------------------------------------------------
                            WELCOME TO API APPLICATION
                          WHAT WOULD YOU LIKE TO PERFORM
                -------------------------------------------------------
            ");

            bool end = false;
            while (!end)
            {
                Console.WriteLine(@"
                -------------------------------------------------------

                1. MOST ACTIVE USERS USING THRESHOLD

                2. GET USER WITH HIGHEST COMMENT COUNT

                3. GET USERS BY RECORD DATE USING THRESHOLD

                4. EXIT

                -------------------------------------------------------
                ");

                /*
                 * Getting the User Response from the given options
                 * If user input is wrong, 
                */
                int.TryParse(Console.ReadLine(), out int response);
                 
                if(response == 1)
                {
                    //Threshold:
                    Console.WriteLine("Enter Threshold");

                    int.TryParse(Console.ReadLine(), out int reply);

                    if(reply > 0)
                    {
                        var result = UserController.GetUsernames(reply);

                        Utility.LoopFor(result);
                    }
                    else
                    {
                        Console.WriteLine("Enter a value positive integer greater than 0");
                       // goto Threshold;
                    }
                    
                }
                else if (response == 2)
                {
                    var result = UserController.GetUsernameWithHighestCommentCount();

                    Console.WriteLine(@$"
                            {result}");
                } 
                else if (response == 3)
                {
                //Start:
                    Console.WriteLine("Enter Threshold: Digit Length must be up to 10");

                    string reply = Console.ReadLine();
                    long.TryParse(reply, out long res);

                    if (reply.Length == 10 && res > 0)
                    {
                        var result = UserController.GetUsernamesSortedByRecordDate(res);
                        Utility.LoopFor(result);
                    }                    
                    else
                    {
                        Console.WriteLine("Please, Enter 10 positive digit numbers");
                        //goto Start;
                    }
                } 
                else if (response == 4)
                {
                    end = true;
                }
                else
                {
                    Console.WriteLine("Enter a Valid Response");
                }
            }
            #endregion END OF USER INTERFACE APPLICATION
        }
    }
}
