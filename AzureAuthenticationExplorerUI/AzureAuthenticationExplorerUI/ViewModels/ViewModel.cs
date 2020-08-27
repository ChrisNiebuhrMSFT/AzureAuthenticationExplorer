using AzureAuthenticationExplorerUI.Commands;
using AzureAuthenticationExplorerUI.Models;
using System.Windows.Input;

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
            //Create a Sampleinstace for Authenticationdata
            AuthData = new AuthenticationData
            {
                ClientSecret = "Streng geheim",
                ClientID = "de8bc8b5-d9f9-48b1-a8ad-b748da725064",
                TenantID = "f22d8e2c-d37c-4b2f-9b0b-b7110232ff3d",
                RedirectURI = "http://localhost"
            };
        }
        public AuthenticationData AuthData { get; set; }
        public bool AuthCodeChecked { get; set; }
        public bool DeviceCodeChecked { get; set; }
        public bool ClientCodeChecked { get; set; }

        public ICommand LogOnCommand { get { return _LogOnCommand; } }
    }
}
