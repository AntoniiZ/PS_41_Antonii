using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLayer.Database;
using DataLayer.Model;

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for LogsList.xaml
    /// </summary>
    public partial class LogsList : UserControl
    {
        public LogsList()
        {
            InitializeComponent();

            using (var context = new DatabaseContext())
            {
                var records = context.UserLogs.ToList();
                logs.DataContext = records;
            }
        }
        private void LogDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (logs.SelectedItem is not UserLog log)
            {
                return;
            }
            MessageBox.Show(log.Message, String.Format("Log {0} on {1}", log.Id, log.Date));
        }
    }
}
