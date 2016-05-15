using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using Edzesterv_Osszeallito_Business_Desktop_Client.Tools;
using Edzesterv_Osszeallito_Business_Desktop_Client.Views.Windows;
using Edzesterv_Osszeallito_MVVM;

#region Namespace
namespace Edzesterv_Osszeallito_Business_Desktop_Client.ViewModels.Windows
{
    #region Class
    public sealed class RegistrationViewModel : ViewModel
    {
        #region Globals
        private ICommand _ResetCommand;
        private ICommand _SaveCommand;
        private ICommand _ImageSelectCommand;
        private RegistrationView _RegistrationView;
        private string _Username;
        private string _Password;
        private string _PasswordAgain;
        private string _Name;
        private Image _Image;
        private byte[] _Profile;
        #endregion Globals

        #region Constructor
        public RegistrationViewModel(RegistrationView RegistrationView)
        {
            this._RegistrationView = RegistrationView;
        }
        #endregion Constructor

        #region Binding Properties
        public byte[] Profile
        {
            get
            {
                return _Profile;
            }
            set
            {
                _Profile = value;
                NotifyPropertyChanged("Profile");
            }
        }
        #endregion Binding Properties

        #region Binding Commands
        public ICommand ResetCommand
        {
            get
            {
                if (_ResetCommand == null)
                {
                    _ResetCommand = new ActionCommandWithoutParameter(ResetAction);
                }
                return _ResetCommand;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new ActionCommandWithoutParameter(SaveAction);
                }
                return _SaveCommand;
            }
        }

        public ICommand ImageSelectCommand
        {
            get
            {
                if (_ImageSelectCommand == null)
                {
                    _ImageSelectCommand = new ActionCommandWithoutParameter(ImageSelectAction);
                }
                return _ImageSelectCommand;
            }
        }

        #endregion Binding Commands

        #region Functions
        private void SaveAction()
        {

        }

        private void ResetAction()
        {
            if (MessageBox.Show("Biztos hogy visszaállítod alapértelmezettként?", "Alapértelmezetté visszaállítása", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                GC.Collect();

                GC.Collect();
            }
        }

        private void ImageSelectAction()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 

            dlg.Filter = "Képfájlok |*.bmp;*.jpg;*.jpeg;*.png;*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                Image img = Image.FromFile(dlg.FileName);
                GC.Collect();
                if (img.Width == img.Height)
                {
                    if (dlg.FileName.Split('.')[1]=="bmp")
                    Profile = ImageToByteConverter.ImageToByteArrayBitmap(Image.FromFile(dlg.FileName));
                    if (dlg.FileName.Split('.')[1] == "gif")
                        Profile = ImageToByteConverter.ImageToByteArrayGif(Image.FromFile(dlg.FileName));
                    if (dlg.FileName.Split('.')[1] == "jpeg"|| dlg.FileName.Split('.')[1] == "jpg")
                        Profile = ImageToByteConverter.ImageToByteArrayJpeg(Image.FromFile(dlg.FileName));
                    if (dlg.FileName.Split('.')[1] == "png")
                        Profile = ImageToByteConverter.ImageToByteArrayPng(Image.FromFile(dlg.FileName));
                }
                else
                {
                    WarriorMessageBox mBox = new WarriorMessageBox("Kép méret", "A kép szélessége nem egyezik a magasságával és/vagy fordítva!", ButtonTypes.OK, IconTypes.Error);
                    mBox.ShowDialog();
                }
                GC.Collect();
                GC.SuppressFinalize(true);
            }


        }
        #endregion Functions
    }
    #endregion Class
}
#endregion Namespace
