using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TraceavitProDesktop.converters;

class JobSelectBgColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var result = Brushes.DarkCyan;
        if (value is bool val)
        {
            result = val ? Brushes.CornflowerBlue : Brushes.LightGray;
        }
        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}