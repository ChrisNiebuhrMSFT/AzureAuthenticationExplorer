using AzureAuthenticationExplorerUI.Authentication;
using AzureAuthenticationExplorerUI.Converters;
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
            if(_ViewModel.InterActiveChecked)
            {
                IsEnabled = !(string.IsNullOrEmpty(_ViewModel.AuthData.ClientID) || string.IsNullOrEmpty(_ViewModel.AuthData.TenantID)
                || string.IsNullOrEmpty(_ViewModel.AuthData.RedirectURI) || _ViewModel.Authenticator.IsConnected);
            }
            if (_ViewModel.SilentLogonChecked)
            {
                IsEnabled = !(string.IsNullOrEmpty(_ViewModel.AuthData.ClientID) || string.IsNullOrEmpty(_ViewModel.AuthData.TenantID)
                || string.IsNullOrEmpty(_ViewModel.AuthData.RedirectURI) || _ViewModel.Authenticator.IsConnected)
                && System.IO.File.Exists(TokenCacheHelper.CacheFilePath);

            }
            return IsEnabled;
        }

        public async void Execute(object parameter)
        {
            string result;
            _ViewModel.ResultTextData.ResultText = string.Empty;
            if (_ViewModel.InterActiveChecked)
            {
                try
                {
                    result = await _ViewModel.Authenticator.AuthenticateInteractive();
                    _ViewModel.ResultTextData.ResultText = result;
                }
                catch (Exception ex)
                {
                    _ViewModel.ResultTextData.ResultText = ex.Message;
                }
            }

            if (_ViewModel.SilentLogonChecked)
            {
                result = await _ViewModel.Authenticator.AuthenticateSilent();
                if (result != null)
                    _ViewModel.ResultTextData.ResultText = result; 
                else
                   _ViewModel.ResultTextData.ResultText = await _ViewModel.Authenticator.AuthenticateInteractive();
              
            }
        }
    }
}
