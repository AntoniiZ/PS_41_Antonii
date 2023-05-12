using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WelcomeExtended.Loggers;
using WelcomeExtended.Helpers;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace WelcomeExtended.Others
{
    public class LogRecords
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("LogRecords");

        public static void LogInfo(string info)
        {

            string docPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "logRecords.txt"), true))
            {
                outputFile.WriteLine(info);
            }
        }


        public delegate void ActionOnInfo(string info);
    }
}
