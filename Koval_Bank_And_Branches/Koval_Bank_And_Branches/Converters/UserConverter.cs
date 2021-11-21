using Koval_Bank_And_Branches.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Koval_Bank_And_Branches.Converters
{
    class UserConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                switch ((Role)value)
                {
                    case Role.Manager:
                        return new BitmapImage(new Uri($@"../Images/{parameter}/Manager.png", UriKind.Relative));
                    case Role.Customer:
                        return new BitmapImage(new Uri($@"../Images/{parameter}/Customer.png", UriKind.Relative));
                    default:
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
