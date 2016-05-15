using Edzesterv_Osszeallito_MVVM;

namespace Edzesterv_Osszeallito_Business_Desktop_Client.Models.Generals
{
    public sealed class DynamicButton : Model
    {
        #region Private Members
        private string _Text;
        private string _ClickCommand;
        #endregion Private Members

        #region Public Members
        public string Text
        {
            get { return _Text; }
            set { _Text = value; NotifyPropertyChanged("Text"); }
        }

        public string ClickCommand
        {
            get { return _ClickCommand; }
            set { _ClickCommand = value; NotifyPropertyChanged("ClickCommand"); }
        }
        #endregion
    }
}
