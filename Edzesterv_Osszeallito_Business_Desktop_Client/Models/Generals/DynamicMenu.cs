using System.Collections.ObjectModel;
using Edzesterv_Osszeallito_MVVM;

namespace Edzesterv_Osszeallito_Business_Desktop_Client.Models.Generals
{
    public sealed class DynamicMenu : Model
    {
        #region Private Members
        private string _Title;
        private ObservableCollection<SubDynamicMenu> _SubDynamicMenu;
        private string _ClickCommand;
        #endregion Private Members

        #region Public Members
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                NotifyPropertyChanged("Title");
            }
        }
        
        public ObservableCollection<SubDynamicMenu> SubDynamicMenu
        {
            get
            {
                return _SubDynamicMenu;
            }
            set
            {
                _SubDynamicMenu = value;
                NotifyPropertyChanged("SubDynamicMenu");
            }
        }

        public string ClickCommand
        {
            get
            {
                return _ClickCommand;
            }
            set
            {
                _ClickCommand = value;
                NotifyPropertyChanged("ClickCommand");
            }
        }
        #endregion Public Members
    }
}
