using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Edzesterv_Osszeallito_Business_Desktop_Client.Models.Generals;
using Edzesterv_Osszeallito_Business_Desktop_Client.ViewModels.UserControls;
using Edzesterv_Osszeallito_Business_Desktop_Client.Views.UserControls;
using Edzesterv_Osszeallito_Business_Desktop_Client.Views.Windows;
using Edzesterv_Osszeallito_MVVM;

namespace Edzesterv_Osszeallito_Business_Desktop_Client.ViewModels.Windows
{
    public sealed class MasterDatasViewModel : ViewModel
    {
        #region Globals
        private MasterDatasView _MasterDatasView;
        private bool isSaved = true;
        private ObservableCollection<DynamicMenu> _MasterDatasDynamicMenu;
        private ICommand _MenuCommand;
        private FrameworkElement _ContentControlView;
        #endregion Globals
        #region Constructor
        public MasterDatasViewModel(MasterDatasView MasterDatasView)
        {
            _MasterDatasView = MasterDatasView;
            _MasterDatasView.Closing += _MasterDatasView_Closing;
            SetDynamicMenu();
        }

        private void _MasterDatasView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isSaved)
            {
                using (WarriorMessageBox mBox = new WarriorMessageBox("Bezárás megerősítése!", "Az ablakon nem mentett változások vannak. Biztos be szeretnéd zárni?", ButtonTypes.YesNo, IconTypes.Warning))
                {
                    if (mBox.ShowDialog() == ButtonResults.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
                e.Cancel = false;
        }
        #endregion Constructor
        #region Binding Properties
        public ObservableCollection<DynamicMenu> MasterDatasDynamicMenu
        {
            get
            {
                return _MasterDatasDynamicMenu;
            }
            set
            {
                _MasterDatasDynamicMenu = value;
                NotifyPropertyChanged("MasterDatasDynamicMenu");
            }
        }
        #endregion Binding Properties
        #region Binding Commands
        public ICommand MenuCommand
        {
            get
            {
                if (_MenuCommand == null)
                    _MenuCommand = new ActionCommandWithParameter(MenuAction);
                return _MenuCommand;
            }
        }

        public FrameworkElement ContentControlView
        {
            get
            {
                return _ContentControlView;
            }set
            {
                _ContentControlView = value;
                NotifyPropertyChanged("ContentControlView");
            }
        }
        #endregion Binding Commands
        #region Functions
        private void SetDynamicMenu()
        {
            MasterDatasDynamicMenu = new ObservableCollection<DynamicMenu>();
            MasterDatasDynamicMenu.Add(new DynamicMenu { Title = "Testtömeg Index Törzsadatok", ClickCommand = "EditBMIValuesMasterDatasUC" });
            MasterDatasDynamicMenu.Add(new DynamicMenu { Title = "Izomcsoport Törzsadatok", ClickCommand = "EditMuscleGroupsMasterDatasUC" });
            MasterDatasDynamicMenu.Add(new DynamicMenu { Title = "Mértékegység Törzsadatok", ClickCommand = "EditUnitAmountsMasterDatasUC" });
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

        public void EditBMIValuesMasterDatasUC()
        {
            if (ContentControlView != null)
            {
                ContentControlView.DataContext = null;
                ContentControlView = null;
            }
            ContentControlView = new EditBMIValuesMasterDatasView();
            ContentControlView.DataContext = new EditBMIValuesMasterDatasViewModel();
        }

        public void EditMuscleGroupsMasterDatasUC()
        {

        }

        public void EditUnitAmountsMasterDatasUC()
        {

        }

        #endregion Functions
        #region Events

        #endregion Events
    }
}
