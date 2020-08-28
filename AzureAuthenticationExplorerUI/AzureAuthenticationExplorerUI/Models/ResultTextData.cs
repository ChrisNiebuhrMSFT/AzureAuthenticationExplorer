using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAuthenticationExplorerUI.Models
{
    public class ResultTextData : BaseModel
    {
        private string _ResultText;

        public string ResultText
        {
            get { return _ResultText; }
            set { _ResultText = value; OnPropertyChanged(); }
        }
    }
}
