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
    class CountMoreThanZeroToBoolConverter : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static CountMoreThanZeroToBoolConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new CountMoreThanZeroToBoolConverter();
            return _converter;
        }
        public CountMoreThanZeroToBoolConverter()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from integer count to bool
            int _value = (int)value;
            //true if the count is greater than 0, false otherwise
            return _value > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("CountMoreThanZeroToBoolConverter is a OneWay converter.");
        }
    }
}
