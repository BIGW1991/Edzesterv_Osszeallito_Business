using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edzesterv_Osszeallito_Business_Desktop_Client.Views.Windows;
using Edzesterv_Osszeallito_MVVM;

namespace Edzesterv_Osszeallito_Business_Desktop_Client.ViewModels.Windows
{
    #region Class
    public sealed class ExceptionViewModel : ViewModel
    {
        #region Globals
        private string exceptionText;
        private ExceptionView exceptionView;
        #endregion Globals

        #region Constructor
        public ExceptionViewModel(string ExceptionText, ExceptionView exceptionView)
        {
            this.ExceptionText = ExceptionText;
            this.exceptionView = exceptionView;
        }
        #endregion Constructor

        #region Properties
        public string ExceptionText
        {
            get
            {
                return exceptionText;
            }
            set
            {
                exceptionText = value;
                NotifyPropertyChanged("ExceptionText");
            }
        }
        #endregion Properties
    }
    #endregion Class
}
