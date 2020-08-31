using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using REST_API.Model;

namespace REST_API.Controller
{
    public class UserController : IUserController
    {
        /*
         * Explicit Interface Iimplementation
         * Using non-static methods, even if they do not access 
         * any instance specific members
        */
        List<string> IUserController.GetUsernames(int threshold)
        {
            return UserController.GetUsernames(threshold);
        }

        string IUserController.GetUsernameWithHighestCommentCount()
        {
            return UserController.GetUsernameWithHighestCommentCount();
        }

        List<string> IUserController.GetUsernamesSortedByRecordDate(int threshold)
        {
            return UserController.GetUsernamesSortedByRecordDate(threshold);
        }

        /*
         * Method to Retrieve the names of the most active authors using 
         * submission count as the criteria according to a set threshold
        */
        public static List<string> GetUsernames(int threshold)
        {
            List<string> result = new List<string>();
            // Query my User List using LINQ
            result = DB.User.Where(x => x.SubmissionCount >= threshold)
                            .OrderByDescending(x => x.SubmissionCount)
                            .Select(x => x.Username)
                            .ToList();

            // return the List populated result
            return result;
        }

        // Method to Retrieve the names of author with highest comment count
        public static string GetUsernameWithHighestCommentCount()
        {
            string result = "";

            // Query my User List using LINQ
            result = DB.User.OrderByDescending(x => x.CommentCount)
                            .Select(x => x.Username)
                            .FirstOrDefault();

            // return the populated string result
            return result;
        }

        /*
        * Method to Retrieve the names of authors sorted by when
        * their record was created according to a set threshold
       */
        public static List<string> GetUsernamesSortedByRecordDate(int threshold)
        {
            // Setting a Date Time reference to 1970
            DateTime time = new DateTime(1970, 1, 1);
            // Offsetting the Date reference into seconds from the given Date Time Reference
            DateTime userTime = time.AddSeconds(threshold);

            List<string> result = new List<string>();

            /*
             * Query my User List using LINQ and Offsetting the Date Time Reference 
             * into seconds for Querying the List
            */
            result = DB.User.Where(x => time.AddSeconds(x.CreatedAt) >= userTime)
                            .OrderByDescending(x => x.CreatedAt)
                            .Select(x => x.Username)
                            .ToList();
            // return the List populated result
            return result;
        }
    }
}
