using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using REST_API.Model;

namespace REST_API.Controller
{
    public class UserController : IUserController
    {
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

        public static List<string> GetUsernames(int threshold)
        {
            List<string> result = new List<string>();
            result = DB.User.Where(x => x.submission_count >= threshold)
                            .OrderByDescending(x => x.submission_count)
                            .Select(x => x.username)
                            .ToList();

            return result;
        }

        public static string GetUsernameWithHighestCommentCount()
        {
            string result = "";

            result = DB.User.OrderByDescending(x => x.comment_count)
                            .Select(x => x.username)
                            .FirstOrDefault();

            return result;
        }

        public static List<string> GetUsernamesSortedByRecordDate(int threshold)
        {
            DateTime time = new DateTime(1970, 1, 1);
            DateTime userTime = time.AddSeconds(threshold);

            List<string> result = new List<string>();

            result = DB.User.Where(x => time.AddSeconds(x.created_at) >= userTime)
                            .OrderByDescending(x => x.created_at)
                            .Select(x => x.username)
                            .ToList();

            return result;
        }
    }
}
