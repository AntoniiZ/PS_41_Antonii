using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WelcomeExtended.Loggers;
using WelcomeExtended.Helpers;
using System.IO;
using DataLayer.Database;
using Welcome.Model;
using DataLayer.Model;

namespace DataLayer.Others
{
    public class DBLogRecords
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("DBLogRecords");

        public static void LogInfo(string date, string info)
        {

            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.Add<UserLog>(new UserLog()
                {
                    Date = date,
                    Message = info
                });
                context.SaveChanges();
            }
        }


        public delegate void ActionOnInfo(string date, string info);
    }
}
