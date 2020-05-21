using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace ValueConverters
{
    public class BoolToRedOrGreen : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static BoolToRedOrGreen _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new BoolToRedOrGreen();
            return _converter;
        }
        public BoolToRedOrGreen()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from bool to color
            bool _value = (bool)value;
            if (_value)
            {
                return Brushes.Green;
            }
            else
            {
                return Brushes.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("BoolToRedOrGreen is a OneWay converter.");
        }
    }
}
