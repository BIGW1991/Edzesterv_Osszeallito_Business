using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Edzesterv_Osszeallito_Business_Desktop_Client.Tools;
using Edzesterv_Osszeallito_Business_Desktop_Client.Views.Windows;
using Edzesterv_Osszeallito_Data_Business;
using Edzesterv_Osszeallito_MVVM;

namespace Edzesterv_Osszeallito_Business_Desktop_Client.ViewModels.Windows
{
    public sealed class LogInViewModel : ViewModel
    {
        #region Globals
        private LogInView _LogInView;
        private ICommand _LogInCommand;
        private ICommand _RegistrationCommand;
        private string _Username;
        private string _Password;
        private bool _KeepLogIn;
        #endregion Globals

        #region Constructor
        public LogInViewModel(LogInView logInView)
        {
            this._LogInView = logInView;
        }
        #endregion Constructor

        #region Binding Commands
        public ICommand LogInCommand
        {
            get
            {
                return (_LogInCommand == null) ? _LogInCommand = new ActionCommandWithoutParameter(LogInAction) : _LogInCommand;
            }
        }

        public ICommand RegistrationCommand
        {
            get
            {
                return (_RegistrationCommand == null) ? _RegistrationCommand = new ActionCommandWithoutParameter(RegistrationAction) : _RegistrationCommand;
            }
        }
        #endregion Binding Commands

        #region Binding Properties
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
                NotifyPropertyChanged("Username");
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                NotifyPropertyChanged("Password");
            }
        }


        public bool KeepLogIn
        {
            get
            {
                return _KeepLogIn;
            }
            set
            {
                _KeepLogIn = value;
                NotifyPropertyChanged("KeepLogIn");
            }
        }
        #endregion Binding Properties

        #region Functions
        private void LogInAction()
        {
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrWhiteSpace(Username))
            {
                if (!string.IsNullOrEmpty(Password) && !string.IsNullOrWhiteSpace(Password))
                {
#if DEBUG
                    using (TrainingPlanBusinessServerEntities db = new TrainingPlanBusinessServerEntities())
                    {
#else
                        using (TrainingPlanBusinessEntities db = new TrainingPlanBusinessEntities())
                        {
#endif
                        db.Database.Log = Console.Write;
                        db.Database.Initialize(false);
                        db.Configuration.ProxyCreationEnabled = false;
                        Users findUser = db.Users.Where(user => user.Username == Username).FirstOrDefault();
                        if (findUser == null)
                        {
                            WarriorMessageBox mBox = new WarriorMessageBox("HIBA!", "Nincs ilyen felhasználó!", ButtonTypes.OK, IconTypes.Error);
                            mBox.ShowDialog();
                        }
                        else
                        {
                            Users selectedUser = (findUser.Password == Password) ? findUser : null;
                            if (selectedUser == null)
                            {
                                WarriorMessageBox mBox = new WarriorMessageBox("HIBA!", "A jelszó hibás!", ButtonTypes.OK, IconTypes.Error);
                                mBox.ShowDialog();
                            }
                            else
                            {
                                MainView mainView = new MainView();
                                mainView.DataContext = new MainViewModel(mainView, selectedUser, KeepLogIn);
                                mainView.Show();
                                _LogInView.Close();
                            }
                        }
                    }
                }
                else
                {
                    WarriorMessageBox mBox = new WarriorMessageBox("HIBA!", "A jelszó nem lehet üres!", ButtonTypes.OK, IconTypes.Error);
                    mBox.ShowDialog();
                }
            }
            else
            {
                WarriorMessageBox mBox = new WarriorMessageBox("HIBA!", "A felhasználónév nem lehet üres!", ButtonTypes.OK, IconTypes.Error);
                mBox.ShowDialog();
            }
        }

        private void RegistrationAction()
        {
            RegistrationView registrationView = new RegistrationView();
            registrationView.DataContext = new RegistrationViewModel(registrationView);
            registrationView.ShowDialog();
        }
        #endregion Functions
    }
}
