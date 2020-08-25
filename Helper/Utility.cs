using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REST_API.Helper
{
    public class Utility
    {
        public static void LoopFor(IEnumerable<string> result)
        {
            foreach (var item in result.Distinct())
            {
                Console.WriteLine(@$"
                            {item}");
            }
        }

    }
}
