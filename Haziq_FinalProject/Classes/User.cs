using System;
using System.Collections.Generic;
using System.Text;

namespace Haziq_FinalProject
{
   public class User
    {
      

      public  string userName { get; set; }

        public string CurrentUserName { get; set; }

        public User(string username)
        {
            this.userName = username;
         
        }

        public void SetUser(string userName)
        {
            CurrentUserName = userName;
        }

        public string GetUser()
        {
            return CurrentUserName;
        }
    }
}
