using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueConverters
{
    class IntToStringConverter : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static IntToStringConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new IntToStringConverter();
            return _converter;
        }
        public IntToStringConverter()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from int to string
            return ((int)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("IntToStringConverter is a OneWay converter.");
        }
    }
}