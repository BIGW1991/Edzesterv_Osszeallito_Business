using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Edzesterv_Osszeallito_Business_Desktop_Client.Converters
{
    public class LogInConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is TextBox)
            {
                if (values[1] is PasswordBox)
                {
                    string username = ((TextBox)values[0]).Text;
                    string password = ((PasswordBox)values[1]).Password;
                    return string.Format("{0}/{1}", username, password);
                }
                else
                {
                    throw new Exception("Hiba történt!");
                }
            }
            else
            {
                throw new Exception("Hiba történt!");
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
