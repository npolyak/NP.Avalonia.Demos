using Avalonia.Data.Converters;
using System;
using System.Globalization;
using System.Linq;

namespace NP.Demos.BindingConvertersSample
{
    public class ReverseStringConverter : IValueConverter
    {
        private static string? ReverseStr(object? value)
        {
            if (value is string str)
            {
                return new string(str.Reverse().ToArray());
            }

            return null;
        }

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return ReverseStr(value);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return ReverseStr(value);
        }
    }
}
