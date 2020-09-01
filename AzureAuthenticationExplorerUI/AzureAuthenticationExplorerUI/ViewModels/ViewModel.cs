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
        private readonly Authenticator _Authenticator;


        //Initialize Data
        public ViewModel()
        {
            _Authenticator = new Authenticator(this);
            _LogOnCommand = new LogOnCommand(this);
            _LogOutCommand = new LogOutCommand(this);

            ResultTextData = new ResultTextData();
            //Create a Sampleinstace for Authenticationdata
            AuthData = new AuthenticationData
            {
                //Exampledata
                //ClientID = "a072bf0d-d9e7-4313-9a5d-ee5e3ee0dad4",
                //TenantID = "f22d8e2c-d37c-4b2f-9b0b-b7110232ff3d",
                //RedirectURI = "http://localhost"
            };

        }
        public AuthenticationData AuthData { get; set; }
        public bool InterActiveChecked { get; set; }
        public bool SilentLogonChecked { get; set; }
        public ResultTextData ResultTextData { get; set; }
        public Authenticator Authenticator { get { return _Authenticator; } }

        public ICommand LogOnCommand { get { return _LogOnCommand; } }
        public ICommand LogOutCommand { get { return _LogOutCommand; } }

    }
}
