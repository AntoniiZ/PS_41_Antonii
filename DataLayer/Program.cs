using DataLayer.Database;
using DataLayer.Model;
using Welcome.Others;
using Welcome.Model;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using System.Linq;
using System.Xml.Linq;
using DataLayer.Others;

namespace DataLayer
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                /*context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Name = "user",
                    Password = "password",
                    Expires = DateTime.Now,
                    Role = UserRolesEnum.STUDENT
                });
                context.SaveChanges();*/

                string username, pass;
                Console.WriteLine("Enter user: ");
                username = Console.ReadLine();
                Console.WriteLine("Enter pass: ");
                pass = Console.ReadLine();

                var users = context.Users.ToList();

                var retrieveUser = (from user in users
                                   where user.Name == username && user.Password == pass
                                   select user).ToList();

                var info = new DBLogRecords.ActionOnInfo(DBLogRecords.LogInfo);

                if (retrieveUser.Count == 0)
                {
                    Console.WriteLine("User not found");
                    info(DateTime.Now.ToString("d MMMM yyyy HH:mm"), 
                        String.Format("Tried to authenticate USER ({0}) but not found or wrong credentials ", username));
                }
                else
                {
                    Console.WriteLine("Valid user and pass");
                    info(DateTime.Now.ToString("d MMMM yyyy HH:mm"), String.Format("Successfully authenticated USER ({0}) ", username));
                }
            }
            

        }
    }

}
