using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System;
using System.Windows;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.converters;

public class StationTypeToVisibilityConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var stype = (StationType)value;
        var ptype = (StationType)parameter;

        if (stype==ptype)
        {
            return Visibility.Visible;
        }
        else
        {
            return Visibility.Collapsed;
        }
        
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class StationTypeToVisibilityNegativeConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var stype = (StationType)value;
        var ptype = (StationType)parameter;

        if (stype != ptype)
        {
            return Visibility.Visible;
        }
        else
        {
            return Visibility.Collapsed;
        }

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}