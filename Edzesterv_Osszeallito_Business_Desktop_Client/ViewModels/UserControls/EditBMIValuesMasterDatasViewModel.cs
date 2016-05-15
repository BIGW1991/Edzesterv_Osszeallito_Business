using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Edzesterv_Osszeallito_Business_Desktop_Client.ViewModels.Windows;
using Edzesterv_Osszeallito_Data_Business;
using Edzesterv_Osszeallito_MVVM;

namespace Edzesterv_Osszeallito_Business_Desktop_Client.ViewModels.UserControls
{
    public sealed class EditBMIValuesMasterDatasViewModel : ViewModel
    {
        #region Globals
        private ObservableCollection<MasterDatas_BMIValues> _BMIValuesMasterDatas;
        private ICommand _EditCommand;
        private ICommand _DeleteCommand;
        #endregion Globals

        #region Constructor
        public EditBMIValuesMasterDatasViewModel()
        {
            LoadMasterDatas();
        }
        #endregion Constructor

        #region Properties
        public ObservableCollection<MasterDatas_BMIValues> BMIValuesMasterDatas
        {
            get
            {
                return _BMIValuesMasterDatas;
            }
            set
            {
                _BMIValuesMasterDatas = value;
                NotifyPropertyChanged("BMIValuesMasterDatas");
            }
        }

        private void EditAction(object obj)
        {

        }


        private void DeleteAction(object obj)
        {
            WarriorMessageBox mBox = new WarriorMessageBox("Hello!","Hello!",ButtonTypes.OK,IconTypes.Information);
            mBox.ShowDialog();
        }

        private void LoadMasterDatas()
        {
            using (TrainingPlanBusinessServerEntities db =new TrainingPlanBusinessServerEntities())
            {
                db.Database.Log = Console.Write;
                db.Database.Initialize(false);
                db.Configuration.ProxyCreationEnabled = false;
                BMIValuesMasterDatas = new ObservableCollection<MasterDatas_BMIValues>(db.MasterDatas_BMIValues.ToList());
            }
        }
        #endregion Properties

        #region Commands
        public ICommand EditCommand
        {
            get
            {
                if (_EditCommand == null)
                {
                    _EditCommand = new ActionCommandWithParameter(EditAction);
                }
                return _EditCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new ActionCommandWithParameter(DeleteAction);
                }
                return _DeleteCommand;
            }
        }

        #endregion Commands
    }
}
