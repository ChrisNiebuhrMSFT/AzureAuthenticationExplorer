using AzureAuthenticationExplorerUI.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace AzureAuthenticationExplorerUI.Models
{
    /// <summary>
    /// Represents the Text for the Authentication results
    /// and also the Readable data of the JWT
    /// </summary>
    public class ResultTextData : BaseModel
    {
        private string _ResultText;
        private string _ReadableToken;

        public string ResultText
        {
            get { return _ResultText; }
            set
            {
                _ResultText = value;
                if (!string.IsNullOrEmpty(_ResultText))
                    ReadableToken = JWTConverter.ConvertFromJWT(_ResultText);
                else
                    ReadableToken = string.Empty;
                OnPropertyChanged();
            }
        }

        public string ReadableToken
        {
            get { return _ReadableToken; }
            private set { _ReadableToken = value; OnPropertyChanged(); }
        }
    }
}
