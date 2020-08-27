namespace AzureAuthenticationExplorerUI.Models
{
    /// <summary>
    /// Represents the Authenticationdata
    /// </summary>
    public class AuthenticationData : BaseModel
    {

        //ClientID of Azure App
        private string _ClientID;
        public string ClientID
        {
            get { return _ClientID; }
            set 
            { 
                _ClientID = value;
                ChangeProperty();
            }
        } 
        
        //Azure TenantID
        private string _TenantID;

        public string TenantID
        {
            get { return _TenantID; }
            set 
            { 
                _TenantID = value;
                ChangeProperty();
            }
        }

        //The Clientsecret configured in App-Registration
        private string _ClientSecret;

        public string ClientSecret
        {
            get { return _ClientSecret; }
            set
            {
                _ClientSecret = value;
                ChangeProperty();
            }
        }

        //The Redirect-Uri configured in App-Registration
        private string _RedirectURI;

        public string RedirectURI
        {
            get { return _RedirectURI; }
            set
            { 
                _RedirectURI = value;
                ChangeProperty();
            }
        }     
    }
}
