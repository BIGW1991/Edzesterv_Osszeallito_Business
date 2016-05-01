using Edzesterv_Osszeallito_Business_Desktop_Client.Models.Generals;
using Edzesterv_Osszeallito_Business_Desktop_Client.Views.Windows;
using Edzesterv_Osszeallito_MVVM;

#region Namespace
namespace Edzesterv_Osszeallito_Business_Desktop_Client.ViewModels.Windows
{
    #region Class
    public sealed class RegistrationViewModel : ViewModel
    {
        #region Globals
        private Users user;
        #endregion Globals

        #region Constructor
        public RegistrationViewModel(RegistrationView registrationView)
        {

        }
        #endregion Constructor

        #region Properties
        public Users User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                NotifyPropertyChanged("User");
            }
        }
        #endregion
    }
    #endregion Class
}
#endregion Namespace
