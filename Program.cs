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

            int pageNumber = 0;
            do
            {
                await APIListController.GetAPIDetailsToList(++pageNumber);
            }
            while (pageNumber != APIController.TotalPages);
            

            //var result = UserController.GetUsernames(400);
            
            //foreach(var item in result.Distinct())
            //{
            //    Console.WriteLine(item);
            //}

            //var result2 = UserController.GetUsernameWithHighestCommentCount();

            //Console.WriteLine(result2);

            //var result3 = UserController.GetUsernamesSortedByRecordDate(100000);

            //foreach(var item in result3)
            //{
            //    Console.WriteLine(item);
            //}

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

                int.TryParse(Console.ReadLine(), out int response);
                 
                if(response == 1)
                {
                    Console.WriteLine("Enter Threshold");

                    int.TryParse(Console.ReadLine(), out int reply);

                    var result = UserController.GetUsernames(reply);

                    Utility.LoopFor(result);
                }
                else if (response == 2)
                {
                    var result = UserController.GetUsernameWithHighestCommentCount();

                    Console.WriteLine(@$"
                            {result}");
                } 
                else if (response == 3)
                {
                Start:
                    Console.WriteLine("Enter Threshold: Digit Length must be up to 10");

                    string reply = Console.ReadLine();

                    if(reply.Length == 10)
                    {
                        int.TryParse(reply, out int res);
                        var result = UserController.GetUsernamesSortedByRecordDate(res);
                        Utility.LoopFor(result);
                    }                    
                    else
                    {
                        Console.WriteLine("Please, Enter 10 digit numbers");
                        goto Start;
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
        }
    }
}
