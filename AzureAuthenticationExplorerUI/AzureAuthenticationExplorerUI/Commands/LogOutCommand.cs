using AzureAuthenticationExplorerUI.Authentication;
using AzureAuthenticationExplorerUI.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace AzureAuthenticationExplorerUI.Commands
{
    public class LogOutCommand : ICommand
    {
        //To Access the Viewmodel inside this Class
        private readonly ViewModel _ViewModel;

        public LogOutCommand(ViewModel viewModel)
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
            bool IsEnabled;
            IsEnabled = _ViewModel.Authenticator.IsConnected;

            return IsEnabled;
        }

        public async void Execute(object parameter)
        {
            _ViewModel.ResultTextData.ResultText = string.Empty;
            await _ViewModel.Authenticator.LogoutAccount();
        }
    }
}
