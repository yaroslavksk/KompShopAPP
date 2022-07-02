using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MuraevKursovoi
{
    public partial class App : Application
    {

    }
    public class JoinStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var separator = parameter as string ?? " ";
            return string.Join(separator, values);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var separator = parameter as string ?? " ";
            return (value as string)?.Split(new[] { separator }, StringSplitOptions.None).Cast<object>().ToArray();
        }
    }
}
