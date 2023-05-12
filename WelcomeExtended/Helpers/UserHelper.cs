using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        public static string toString(this User user)
        {
            return user.Name + "-" + user.Role.ToString();
        }

        public static bool ValidateCredentials(UserData userData, string name, string password)
        {

            if (name.Length == 0)
            {
                throw new Exception("The name cannot be empty!");
            }

            if (password.Length == 0)
            {
                throw new Exception("The password cannot be empty!");
            }

            return userData.ValidateUser(name, password);
        }

        public static User GetUser(UserData userData, string name, string password)
        {
            return userData.GetUser(name, password);
        }
    }
}
