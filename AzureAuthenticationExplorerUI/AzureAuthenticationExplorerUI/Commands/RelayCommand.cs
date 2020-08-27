using AzureAuthenticationExplorerUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AzureAuthenticationExplorerUI.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly ViewModel _ViewModel;

        public RelayCommand(ViewModel viewModel)
        {
            _ViewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _ViewModel.AuthCodeChecked || _ViewModel.ClientCodeChecked || _ViewModel.DeviceCodeChecked;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("blubb");
        }
    }
}
