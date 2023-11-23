using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TraceavitProDesktop.converters;

class ByteArrayToImageConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            if (value is byte[] { Length: > 0 } buffer)
            {
                Stream           imageStreamSource = new MemoryStream(buffer);
                PngBitmapDecoder decoder           = new(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource     bitmapSource      = decoder.Frames[0];
                return bitmapSource;
            }
        }
        catch
        {
            //
        }
        return Application.Current.Resources["DefaultCanister"]!;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}