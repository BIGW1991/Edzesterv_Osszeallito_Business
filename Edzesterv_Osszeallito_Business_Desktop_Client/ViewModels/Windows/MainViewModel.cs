using System.Collections.ObjectModel;
using System.Windows;
using Edzesterv_Osszeallito_Business_Desktop_Client.Models.Generals;
using Edzesterv_Osszeallito_Business_Desktop_Client.Views.Windows;
using Edzesterv_Osszeallito_MVVM;

namespace Edzesterv_Osszeallito_Business_Desktop_Client.ViewModels.Windows
{
    public sealed class MainViewModel : ViewModel
    {
        #region Globals
        private MainView _MainView;
        private ObservableCollection<DynamicMenu> _DynamicMenu;
        private ObservableCollection<SubDynamicMenu> _SubDynamicMenu;
        private User _User;
        private FrameworkElement _ContentControlView;
        #endregion Globals

        #region Constructor
        public MainViewModel(MainView MainView, User User)
        {
            this._MainView = MainView;
            this.User = User;
            SetDynamicMenu();
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

        public User User
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

        #endregion Binding Properties

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

            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Kliensek kezelése", ClickCommand = "OpenManagingClientsWindow" });
            DynamicMenu.Add(new DynamicMenu { Title = "Kliensek", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            SubDynamicMenu.Clear();


            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Törzsadatok", ClickCommand = "OpenMasterDatasUC" });
            DynamicMenu.Add(new DynamicMenu { Title = "Beállítások", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            SubDynamicMenu.Clear();

            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Frissítések", ClickCommand = "OpenUpdatesUC" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Súgó megnyitása", ClickCommand = "OpenHelpWindow" });
            SubDynamicMenu.Add(new SubDynamicMenu { Title = "Terméktámogatási kérelem küldése", ClickCommand = "OpenProductSupportUC" });
            DynamicMenu.Add(new DynamicMenu { Title = "Súgó és támogatás", SubDynamicMenu = new ObservableCollection<SubDynamicMenu>(SubDynamicMenu) });
            SubDynamicMenu.Clear();
        }
        #endregion Functions
    }
}
