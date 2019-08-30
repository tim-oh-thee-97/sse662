using System;
using System.Windows;
using System.Windows.Data;

namespace SSE662_Proj1.ValueConverters
{
    [ValueConversion(typeof(string), typeof(Visibility))]
    public class ErrorDockVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(Visibility))
                throw new InvalidOperationException("The target must be of type System.Windows.Visibility");

            if (string.IsNullOrEmpty((string)value))
            {
                return Visibility.Collapsed;
            }

            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
