using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.converters;

class PauseReasonBgButtonConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var bgSelect = Application.Current.Resources["tpBlueBG"] as SolidColorBrush;
        var bg = Application.Current.Resources["tpBlueMain"] as SolidColorBrush; ;


        var reason = value is PauseReasonSelected selected ? selected : PauseReasonSelected.None;
        var param = parameter is PauseReasonSelected p ? p : PauseReasonSelected.None;

        var result = reason == param ? bg : bgSelect;

        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}