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
                 * If user input is wrong, throw a response
                */
                int.TryParse(Console.ReadLine(), out int response);
                 
                if(response == 1)
                {
                    Console.WriteLine("Enter Threshold");

                    int.TryParse(Console.ReadLine(), out int reply);

                    // Check if the response gotten is above 0 integer
                    if(reply > 0)
                    {
                        // Calling GetUsernames method from UserController class
                        // Populating the response to the class method
                        var result = UserController.GetUsernames(reply);

                        Console.ForegroundColor = (ConsoleColor)2;
                        // Utility method for Looping through the List
                        Utility.LoopFor(result);
                        Console.ResetColor();
                    }
                    else
                    {
                        // Response to be displayed when it fails to accept response provided
                        Console.WriteLine("Enter a value positive integer greater than 0");
                    }
                    
                }
                else if (response == 2)
                {
                    // Method to call the GetUsernameWithHighestCommentCount from the UserController class
                    var result = UserController.GetUsernameWithHighestCommentCount();

                    Console.ForegroundColor = (ConsoleColor)2;

                    // Print out the result retrieved
                    Console.WriteLine(@$"
                            {result}");
                    Console.ResetColor();
                } 
                else if (response == 3)
                {
                    Console.WriteLine("Enter Threshold: Digit Length must be up to 10");

                    string reply = Console.ReadLine();
           
                    int.TryParse(reply, out int res);

                    /*
                     * Check if the response Length is equal to 10
                     * and if the response in integer is greater than 0
                    */
                    if (reply.Length == 10 && res > 0)
                    {
                        // Method to call GetUsernamesSortedByRecordDate from the UserController Class
                        var result = UserController.GetUsernamesSortedByRecordDate(res);
                        Console.ForegroundColor = (ConsoleColor)2;
                        // Utility method for Looping through the List
                        Utility.LoopFor(result);
                        Console.ResetColor();
                    }                    
                    else
                    {
                        Console.WriteLine("Please, Enter 10 positive digit numbers");
                    }
                } 
                // End the loop if the response gotten is integer 4
                else if (response == 4)
                {
                    end = true;
                }
                else
                {
                    /*
                     * None of the response matches the response expected
                     * Throw this response
                    */
                    Console.WriteLine("Enter a Valid Response");
                }
            }
            #endregion END OF USER INTERFACE APPLICATION
        }
    }
}
