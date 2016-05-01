using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Edzesterv_Osszeallito_Business_Desktop_Client.Models.Generals;
using Edzesterv_Osszeallito_Business_Desktop_Client.Tools;
using Edzesterv_Osszeallito_Business_Desktop_Client.Views.Windows;
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
            using (new WaitCursor())
            {
                if (!string.IsNullOrEmpty(Username) && !string.IsNullOrWhiteSpace(Username))
                {
                    if (!string.IsNullOrEmpty(Password) && !string.IsNullOrWhiteSpace(Password))
                    {
                        using (TrainingPlanBusinessEntities db = new TrainingPlanBusinessEntities())
                        {
                            Guid ID = (from users in db.Users
                                       where users.Username == Username
                                       select users.ID).SingleOrDefault();
                            if (ID == Guid.Empty)
                            {
                                MessageBox.Show("Nincs ilyen felhasználónév!", "HIBA!", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {

                                User user = (from users in db.Users
                                             where users.Password == Password && users.ID == ID
                                             select users).SingleOrDefault();
                                if (user == null)
                                {
                                    MessageBox.Show("A jelszó nem megfelelő!", "HIBA!", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                else
                                {
                                    MainView mainView = new MainView();
                                    mainView.DataContext = new MainViewModel(mainView, user);
                                    mainView.Show();
                                    _LogInView.Close();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("A jelszó nem lehet üres!", "HIBA!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("A felhasználónév nem lehet üres!", "HIBA!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
