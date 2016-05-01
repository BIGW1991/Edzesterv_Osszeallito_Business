using System;
using Edzesterv_Osszeallito_MVVM;

namespace Edzesterv_Osszeallito_Business_Desktop_Client.Models.Generals
{
    public class Users : Model
    {
        #region Private Members
        private Guid id;
        private string name;
        private string password;
        private DateTime birthday;
        private int age;
        private int height;
        private double weight;
        #endregion Private Members

        #region Public Members
        public Guid ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
                NotifyPropertyChanged("Birthday");
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                NotifyPropertyChanged("Age");
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                NotifyPropertyChanged("Height");
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
                NotifyPropertyChanged("Weight");
            }
        }
        #endregion Public Members
    }
}
