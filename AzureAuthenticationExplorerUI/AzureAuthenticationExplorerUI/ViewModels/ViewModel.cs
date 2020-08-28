using AzureAuthenticationExplorerUI.Commands;
using AzureAuthenticationExplorerUI.Models;
using AzureAuthenticationExplorerUI.Authentication;
using System.Windows.Input;
using System.Reflection;

namespace AzureAuthenticationExplorerUI.ViewModels
{
    /// <summary>
    /// Represents the Viewmodel for this Project
    /// </summary>
    public class ViewModel 
    {
        //Command for the LogOnButton
        private readonly LogOnCommand _LogOnCommand;


        //Initialize Data
        public ViewModel()
        {
            _LogOnCommand = new LogOnCommand(this);

            ResultTextData = new ResultTextData();
            //Create a Sampleinstace for Authenticationdata
            AuthData = new AuthenticationData
            {
                ClientID = "a072bf0d-d9e7-4313-9a5d-ee5e3ee0dad4",
                TenantID = "f22d8e2c-d37c-4b2f-9b0b-b7110232ff3d",
                RedirectURI = "http://localhost"
            };
            Authenticator = new Authenticator(AuthData.TenantID, AuthData.ClientID, AuthData.RedirectURI);
        }
        public AuthenticationData AuthData { get; set; }
        public bool InterActiveChecked { get; set; }
        public bool SilentLogonChecked { get; set; }
        public ResultTextData ResultTextData { get; set; }
        public Authenticator Authenticator { get; }

        public ICommand LogOnCommand { get { return _LogOnCommand; } }

   
    }
}
