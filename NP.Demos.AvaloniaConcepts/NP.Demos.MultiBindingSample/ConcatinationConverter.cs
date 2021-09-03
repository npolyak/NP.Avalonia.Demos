using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NP.Demos.MultiBindingSample
{
    public class ConcatinationConverter : IMultiValueConverter
    {
        // static instance to reference
        public static ConcatinationConverter Instance { get; } =
            new ConcatinationConverter();

        public object? Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Count == 0)
            {
                return null;
            }

            return 
                string.Join("", values.Select(v => v?.ToString()).Where(v => v != null));
        }
    }
}
