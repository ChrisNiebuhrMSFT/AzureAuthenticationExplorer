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
            bool IsEnabled = false;
            if(_ViewModel.AuthCodeChecked)
            {
                IsEnabled = !(string.IsNullOrEmpty(_ViewModel.AuthData.ClientID) || string.IsNullOrEmpty(_ViewModel.AuthData.TenantID)
                    || string.IsNullOrEmpty(_ViewModel.AuthData.RedirectURI));
            }
            if (_ViewModel.DeviceCodeChecked)
            {
                IsEnabled = !(string.IsNullOrEmpty(_ViewModel.AuthData.ClientID) || string.IsNullOrEmpty(_ViewModel.AuthData.TenantID));
            }
            if (_ViewModel.ClientCodeChecked)
            {
                IsEnabled = !(string.IsNullOrEmpty(_ViewModel.AuthData.ClientID) || string.IsNullOrEmpty(_ViewModel.AuthData.TenantID)
                    || string.IsNullOrEmpty(_ViewModel.AuthData.ClientSecret));
            }
            return IsEnabled;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("blubb");
        }
    }
}
