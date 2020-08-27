using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace AzureAuthenticationExplorerUI.Converters
{
    /// <summary>
    /// Converts a Boolean value to a Visibility value
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool vis = (bool)value;

            return true; // vis ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility vis = (Visibility)value;

            return vis == Visibility.Visible;
        }
    }
}
