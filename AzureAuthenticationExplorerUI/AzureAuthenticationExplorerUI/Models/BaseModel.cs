using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace AzureAuthenticationExplorerUI.Models
{
    /// <summary>
    /// Baseclass for all Models in this Project
    /// </summary>
   public class BaseModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        //We use the CallerMemberName Attribute to autopopulate the Callername
        protected void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}
