using AzureAuthenticationExplorerUI.Commands;
using AzureAuthenticationExplorerUI.Models;
using AzureAuthenticationExplorerUI.Authentication;
using System.Windows.Input;
using System.Reflection;
using System.Threading;

namespace AzureAuthenticationExplorerUI.ViewModels
{
    /// <summary>
    /// Represents the Viewmodel for this Project
    /// </summary>
    public class ViewModel 
    {
        //Command for the LogOnButton
        private readonly LogOnCommand  _LogOnCommand;
        private readonly LogOutCommand _LogOutCommand;


        //Initialize Data
        public ViewModel()
        {
            Authenticator = new Authenticator(this);
            _LogOnCommand = new LogOnCommand(this);
            _LogOutCommand = new LogOutCommand(this);

            ResultTextData = new ResultTextData();
            //Create a Sampleinstace for Authenticationdata
            AuthData = new AuthenticationData();

        }
        public AuthenticationData AuthData { get; set; }
        public bool InterActiveChecked { get; set; }
        public bool SilentLogonChecked { get; set; }
        public ResultTextData ResultTextData { get; set; }
        public Authenticator Authenticator { get; }

        public ICommand LogOnCommand { get { return _LogOnCommand; } }
        public ICommand LogOutCommand { get { return _LogOutCommand; } }

    }
}
