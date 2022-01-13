using AutoSzerelo_Common.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Iroda_Client
{
    // Tutorial: https://www.codeproject.com/Articles/683429/Guide-to-WPF-DataGrid-Formatting-Using-Bindings
    class StatusToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Status)value == Status.Finished)
                return new SolidColorBrush(Color.FromRgb(150, 150, 150));
            return new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
