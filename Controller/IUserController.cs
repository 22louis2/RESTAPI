using System;
using System.Collections.Generic;
using System.Text;

namespace REST_API.Controller
{
    public interface IUserController
    {
        // Interfaces the UserController Class must perform
        public List<string> GetUsernames(int threshold);
        public string GetUsernameWithHighestCommentCount();
        public List<string> GetUsernamesSortedByRecordDate(int threshold);
    }
}
