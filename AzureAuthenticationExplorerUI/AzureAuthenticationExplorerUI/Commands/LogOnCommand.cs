using AzureAuthenticationExplorerUI.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace AzureAuthenticationExplorerUI.Commands
{
    /// <summary>
    /// Respresents the Logon Command used in the Viewmodel
    /// </summary>
    public class LogOnCommand : ICommand
    {
        //To Access the Viewmodel inside this Class
        private readonly ViewModel _ViewModel;

        public LogOnCommand(ViewModel viewModel)
        {
            _ViewModel = viewModel;
        }
        /// <summary>
        /// Normally ICommand only works for Routed Events. 
        /// To make this Command work as expected in WPF we have to do this
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Conditions to Enable or Disable the LogonButton
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
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
