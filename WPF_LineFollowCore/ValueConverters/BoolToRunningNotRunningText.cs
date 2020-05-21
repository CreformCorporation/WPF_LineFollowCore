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
    public class BoolToRunningNotRunningText : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static BoolToRunningNotRunningText _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new BoolToRunningNotRunningText();
            return _converter;
        }
        public BoolToRunningNotRunningText()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from bool to string
            bool _value = (bool)value;
            if (_value)
            {
                return "Running";
            }
            else
            {
                return "Not Running";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("BoolToRunningNotRunningText is a OneWay converter.");
        }
    }
}
