using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REST_API.Helper
{
    public class Utility
    {
        // Method to help for looping through a List
        public static void LoopFor(IEnumerable<string> result)
        {
            // Looping through the List provided
            foreach (var item in result)
            {
                Console.WriteLine(@$"
                            {item}");
            }
        }

    }
}
