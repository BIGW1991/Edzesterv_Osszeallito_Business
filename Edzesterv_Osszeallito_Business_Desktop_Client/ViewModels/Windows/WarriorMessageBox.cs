using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Edzesterv_Osszeallito_Business_Desktop_Client.Models.Generals;
using Edzesterv_Osszeallito_Business_Desktop_Client.Views.Windows;
using Edzesterv_Osszeallito_MVVM;

namespace Edzesterv_Osszeallito_Business_Desktop_Client.ViewModels.Windows
{
    public sealed class WarriorMessageBox : ViewModel, IDisposable
    {
        #region Globals
        private string _Title;
        private string _Message;
        private ButtonTypes _ButtonType;
        private IconTypes _IconType;
        private ICommand _ButtonCommand;
        private ButtonResults _ButtonResult;
        private MessageBoxView _MboxView;
        private ObservableCollection<DynamicButton> _MessageBoxButtons;
        #endregion Globals

        #region Constructor
        public WarriorMessageBox(string Title, string Message, ButtonTypes ButtonType = ButtonTypes.OK, IconTypes IconType = IconTypes.None)
        {
            this.Title = Title;
            this.Message = Message;
            _ButtonType = ButtonType;
            _IconType = IconType;
            ButtonLoading();
        }

        #endregion Constructor

        #region Binding Properties
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

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
                NotifyPropertyChanged("Message");
            }
        }

        public string Image
        {
            get
            {
                if (_IconType == IconTypes.Error)
                    return "/Edzésterv Összeállító Business;component/Publics/Images/Error.png";
                if (_IconType == IconTypes.Information)
                    return "/Edzésterv Összeállító Business;component/Publics/Images/Information.png";
                if (_IconType == IconTypes.Question)
                    return "/Edzésterv Összeállító Business;component/Publics/Images/Question.png";
                if (_IconType == IconTypes.Warning)
                    return "/Edzésterv Összeállító Business;component/Publics/Images/Warning.png";
                else
                    return null;
            }
        }

        public ObservableCollection<DynamicButton> MessageBoxButtons
        {
            get
            {
                return _MessageBoxButtons;
            }
            set
            {
                _MessageBoxButtons = value;
                NotifyPropertyChanged("MessageBoxButtons");
            }
        }
        #endregion Binding Properties

        #region Commands
        public ICommand ButtonCommand
        {
            get
            {
                if (_ButtonCommand == null)
                {
                    _ButtonCommand = new ActionCommandWithParameter(ButtonAction);
                }
                return _ButtonCommand;
            }
        }
        #endregion Commands

        #region Functions
        public void ButtonAction(object parameter)
        {
            Type thisType = this.GetType();
            MethodInfo callMethod = thisType.GetMethod(parameter as string);
            callMethod.Invoke(this, null);
        }

        private void ButtonLoading()
        {
            MessageBoxButtons = new ObservableCollection<DynamicButton>();
            if (_ButtonType == ButtonTypes.OK)
            {
                MessageBoxButtons.Add(new DynamicButton { Text = "OK", ClickCommand = "OKAction" });
                return;
            }
            else if (_ButtonType == ButtonTypes.OKCancel)
            {
                MessageBoxButtons.Add(new DynamicButton { Text = "OK", ClickCommand = "OKAction" });
                MessageBoxButtons.Add(new DynamicButton { Text = "Mégse", ClickCommand = "CancelAction" });
                return;
            }
            else if (_ButtonType == ButtonTypes.YesNo)
            {
                MessageBoxButtons.Add(new DynamicButton { Text = "Igen", ClickCommand = "YesAction" });
                MessageBoxButtons.Add(new DynamicButton { Text = "Nem", ClickCommand = "NoAction" });
                return;
            }
            else if (_ButtonType == ButtonTypes.YesNoCancel)
            {
                MessageBoxButtons.Add(new DynamicButton { Text = "Igen", ClickCommand = "YesAction" });
                MessageBoxButtons.Add(new DynamicButton { Text = "Nem", ClickCommand = "NoAction" });
                MessageBoxButtons.Add(new DynamicButton { Text = "Mégse", ClickCommand = "CancelAction" });
                return;
            }
        }

        public ButtonResults ShowDialog()
        {
            _ButtonResult = ButtonResults.Cancel;
            _MboxView = new MessageBoxView();
            _MboxView.DataContext = this;
            _MboxView.ShowDialog();
            return _ButtonResult;
        }

        public void OKAction()
        {
            _ButtonResult = ButtonResults.OK;
            _MboxView.Close();
        }

        public void CancelAction()
        {
            _ButtonResult = ButtonResults.Cancel;
            _MboxView.Close();
        }

        public void YesAction()
        {
            _ButtonResult = ButtonResults.Yes;
            _MboxView.Close();
        }

        public void NoAction()
        {
            _ButtonResult = ButtonResults.No;
            _MboxView.Close();
        }

        public void Dispose()
        {
            GC.Collect();
            _MboxView.Close();
            _MboxView = null;
            GC.Collect();
        }
        #endregion Functions
    }
}
