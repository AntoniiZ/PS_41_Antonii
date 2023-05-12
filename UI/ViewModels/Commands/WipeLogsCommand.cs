using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace UI.ViewModels.Commands
{
    public class WipeLogsCommand : ICommand
    {

        public ViewModelBase ViewModel { get; set; }
        public WipeLogsCommand(ViewModelBase viewModel)
        {
            this.ViewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            this.ViewModel.wipeLogs();
            MessageBox.Show("Logs deleted, reopen window");
        }
    }
}
