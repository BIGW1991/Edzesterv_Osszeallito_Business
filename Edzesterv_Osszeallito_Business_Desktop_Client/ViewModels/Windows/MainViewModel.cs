using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Edzesterv_Osszeallito_Business_Desktop_Client.Models.Generals;
using Edzesterv_Osszeallito_Business_Desktop_Client.Views.Windows;
using Edzesterv_Osszeallito_Data_Business;
using Edzesterv_Osszeallito_MVVM;
using AssemblyInfo;
using System.Reflection;
using System;

namespace Edzesterv_Osszeallito_Business_Desktop_Client.ViewModels.Windows
{
    public sealed class MainViewModel : ViewModel
    {
        #region Globals
        private MainView _MainView;
        private Users _User;
        private bool _KeepLogIn;
        private bool _WindowIsHidden;
        private ObservableCollection<DynamicMenu> _DynamicMenu;
        private ObservableCollection<SubDynamicMenu> _SubDynamicMenu;
        private FrameworkElement _ContentControlView;
        private AssemblyInfos _AssemblyInfo;
        private ICommand _ApplicationExitCommand;
        private ICommand _ShowWindowCommand;
        private ICommand _MenuCommand;
        #endregion Globals
        #region Constructor
        public MainViewModel(MainView MainView, Users User, bool KeepLogIn)
        {
            _MainView = MainView;
            _MainView.Closing += _MainView_Closing;
            this.User = User;
            this.KeepLogIn = KeepLogIn;
            SetDynamicMenu();
            AssemblyInfo = new AssemblyInfos(Assembly.GetExecutingAssembly());
        }
        #endregion Constructor
        #region Binding Properties
        public FrameworkElement ContentControlView
        {
            get
            {
                return _ContentControlView;
            }
            set
            {
                _ContentControlView = value;
                NotifyPropertyChanged("ContentControlView");
            }
        }

        public Users User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
                NotifyPropertyChanged("User");
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
            }
        }

        public bool WindowIsHidden
        {
            get
            {
                return _WindowIsHidden;
            }
            set
            {
                _WindowIsHidden = value;
                NotifyPropertyChanged("WindowIsHidden");
            }
        }

        public ObservableCollection<DynamicMenu> DynamicMenu
        {
            get
            {
                return _DynamicMenu;
            }
            set
            {
                _DynamicMenu = value;
                NotifyPropertyChanged("DynamicMenu");
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

        public AssemblyInfos AssemblyInfo
        {
            get
            {
                return _AssemblyInfo;
            }
            set
            {
                _AssemblyInfo = value;
                NotifyPropertyChanged("AssemblyInfo");
            }
        }
        #endregion Binding Properties
        #region Binding Commands
        public ICommand ApplicationExitCommand
        {
            get
            {
                if (_ApplicationExitCommand == null)
                {
                    _ApplicationExitCommand = new ActionCommandWithoutParameter(ApplicationExitAction);
                }
                return _ApplicationExitCommand;
            }
        }

        public ICommand ShowWindowCommand
        {
            get
            {
                if (_ShowWindowCommand == null)
                {
                    _ShowWindowCommand = new ActionCommandWithoutParameter(ShowWindowAction);
                }
                return _ShowWindowCommand;
            }
        }

        public ICommand MenuCommand
        {
            get
            {
                if (_MenuCommand == null)
                {
                    _MenuCommand = new ActionCommandWithParameter(MenuAction);
                }
                return _MenuCommand;
            }
        }
        #endregion Binding Commands
        #region Functions
        private void SetDynamicMenu()
        {
            SubDynamicMenu = new ObservableCollection<SubDynamicMenu>();
            DynamicMenu = new ObservableCollection<DynamicMenu>();

            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Gyakorlat létrehozása", ClickCommand = "CreateTrainingUserControl" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Gyakorlatok megtekintése, szerkesztése", ClickCommand = "ViewAndEditTrainingUserControl" });
            DynamicMenu.Add(new DynamicMenu { Title = "Gyakorlatok", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            SubDynamicMenu.Clear();

            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Edzésterv létrehozása", ClickCommand = "OpenCreateTrainingPlanUC" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Edzéstervek megtekintése, szerkesztése", ClickCommand = "OpenViewAndEditTrainingPlanWindow" });
            DynamicMenu.Add(new DynamicMenu { Title = "Edzéstervek", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            SubDynamicMenu.Clear();

            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Ételek hozzáadása", ClickCommand = "OpenCreateMealUC" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Ételek megtekintése, szerkesztése", ClickCommand = "OpenViewAndEditMealWindow" });
            DynamicMenu.Add(new DynamicMenu { Title = "Ételek", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            SubDynamicMenu.Clear();

            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Étrendek hozzáadása", ClickCommand = "OpenCreateDietUC" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Étrendek megtekintése, szerkesztése", ClickCommand = "OpenViewAndEditDietWindow" });
            DynamicMenu.Add(new DynamicMenu { Title = "Étrendek", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            SubDynamicMenu.Clear();

            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Testtömeg index kalkulátor", ClickCommand = "OpenBodyMassIndexCalculatorUC" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Alapanyagcsere kalkulátor", ClickCommand = "OpenBasalMetabolicRateCalculatorUC" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Peter Riegel versenyeredmény kalkulátor", ClickCommand = "OpenPeterRiegelResultCalculatorUC" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Pulzustartomány kalkulátor", ClickCommand = "OpenHeartRateCalculatorUC" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Tápanyag és kalória kalkulátor", ClickCommand = "OpenNutrientsAndCaloriesCalulatorUC" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Kalória felhasználás kalkulátor", ClickCommand = "OpenCaloriesConsumptionCalulatorUC" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Életkori tényező kalkulátor", ClickCommand = "OpenAgeFactorCalulatorUC" });
            DynamicMenu.Add(new DynamicMenu { Title = "Kalkulátorok", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            SubDynamicMenu.Clear();

            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Profil szerkesztése", ClickCommand = "OpenEditProfileUC" });
            DynamicMenu.Add(new DynamicMenu { Title = "Profil", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            SubDynamicMenu.Clear();

            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Kliensek hozzáadása", ClickCommand = "OpenAddClientsWindow" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Kliensek kezelése", ClickCommand = "OpenManagingClientsWindow" });
            DynamicMenu.Add(new DynamicMenu { Title = "Kliensek", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            SubDynamicMenu.Clear();

            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Csoportok hozzáadása", ClickCommand = "OpenAddGroupsWindow" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Csoportok kezelése", ClickCommand = "OpenManagingGroupsWindow" });
            DynamicMenu.Add(new DynamicMenu { Title = "Csoportok", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            SubDynamicMenu.Clear();


            //SubDynamicMenu.Add(new SubDynamicMenu { Title = "Törzsadatok", ClickCommand = "OpenMasterDatasWindow" });
            //DynamicMenu.Add(new DynamicMenu { Title = "Beállítások", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            //SubDynamicMenu.Clear();

            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Frissítések", ClickCommand = "OpenUpdatesUC" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Súgó megnyitása", ClickCommand = "OpenHelpWindow" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Terméktámogatási kérelem küldése", ClickCommand = "OpenProductSupportUC" });
            DynamicMenu.Add(new DynamicMenu { Title = "Súgó és támogatás", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            SubDynamicMenu.Clear();
        }

        private void ApplicationExitAction()
        {
            WarriorMessageBox vm = new WarriorMessageBox("Kilépés megerősítése", "Biztos ki szeretnél lépni?", ButtonTypes.YesNo, IconTypes.Question);
            if (vm.ShowDialog() == ButtonResults.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void ShowWindowAction()
        {
            _MainView.Show();
            WindowIsHidden = false;
        }

        private void MenuAction(object obj)
        {
            try
            {
                Type type = GetType();
                MethodInfo methodInfo = type.GetMethod(obj as string);
                methodInfo.Invoke(this, null);
            }
            catch (NullReferenceException) { }
        }

        public void OpenMasterDatasWindow()
        {
            MasterDatasView masterDatasView = new MasterDatasView();
            masterDatasView.DataContext = new MasterDatasViewModel(masterDatasView);
            masterDatasView.Show();
        }
        #endregion Functions
        #region Events
        private void _MainView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _MainView.Hide();
            WindowIsHidden = KeepLogIn;
            e.Cancel = KeepLogIn;
        }
        #endregion Events     
    }
}
