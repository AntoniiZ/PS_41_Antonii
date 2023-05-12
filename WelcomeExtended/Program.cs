using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;
using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Others;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using Microsoft.Extensions.Logging;
using WelcomeExtended.Loggers;

namespace WelcomeExtended
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserData userData = new UserData();

                User newUser = new User("student", "123", UserRolesEnum.STUDENT);
                userData.AddUser(newUser);
                userData.AddUser(new User("Student2", "123", UserRolesEnum.STUDENT));
                userData.AddUser(new User("Teacher", "1234", UserRolesEnum.PROFESSOR));
                userData.AddUser(new User("Admin", "1235", UserRolesEnum.ADMIN));

                Console.WriteLine("Type username: ");
                string name = Console.ReadLine();

                Console.WriteLine("Type password: ");
                string pass = Console.ReadLine();

                var info = new LogRecords.ActionOnInfo(LogRecords.LogInfo);
                bool exists = UserHelper.ValidateCredentials(userData, name, pass);

                if (exists)
                {
                    info(String.Format("[{0}] USER ({1}) LOGGED IN SUCCESSFULLY ", DateTime.Now.ToString("d MMMM yyyy HH:mm"), name));
                    User user = UserHelper.GetUser(userData, name, pass);
                    Console.WriteLine(user.toString());
                }
                else
                {
                    var err = "User not found";
                    info(String.Format("[{0}] USER ({1}) FAILED LOGIN ATTEMPT - {2} ", DateTime.Now.ToString("d MMMM yyyy HH:mm"), name, err));
                    throw new Exception(err);
                }

            }
            catch (Exception e)
            {
                var log = new Delegates.ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}
