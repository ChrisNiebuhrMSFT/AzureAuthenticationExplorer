
using System.Threading.Tasks;

namespace AzureAuthenticationExplorerUI.Models
{
    /// <summary>
    /// Represents the Authenticationdata
    /// </summary>
    public class AuthenticationData : BaseModel
    {

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

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
            }
        }

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
