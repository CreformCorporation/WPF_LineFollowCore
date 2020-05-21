using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueConverters
{
    public class CountToVisibilityCollapsedConverter : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static CountToVisibilityCollapsedConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new CountToVisibilityCollapsedConverter();
            return _converter;
        }
        public CountToVisibilityCollapsedConverter()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from integer count to visibility
            int _value = (int)value;
            //visible if the count is greater than 0, collapsed otherwise
            return _value > 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("CountToVisibilityCollapsedConverter is a OneWay converter.");
        }
    }
}
