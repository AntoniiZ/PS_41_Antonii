using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataLayer.Database;
using DataLayer.Model;
using UI.ViewModels.Commands;
using DataLayer.Database;
namespace UI.ViewModels
{
    public class ViewModelBase
    {
        public WipeLogsCommand WipeLogsCommand { get; set; }
        public ViewModelBase()
        {
            this.WipeLogsCommand = new WipeLogsCommand(this);
        }

        public void wipeLogs()
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();

                var logs = context.UserLogs;
                logs.RemoveRange(logs);
                context.SaveChanges();
            }
        }
    }
}
