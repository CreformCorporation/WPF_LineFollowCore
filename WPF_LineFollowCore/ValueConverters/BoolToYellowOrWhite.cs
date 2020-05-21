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
    class BoolToYellowOrWhite : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static BoolToYellowOrWhite _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new BoolToYellowOrWhite();
            return _converter;
        }
        public BoolToYellowOrWhite()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from bool to color
            bool _value = (bool)value;
            if (_value)
            {
                return Brushes.Yellow;
            }
            else
            {
                return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("BoolToYellowOrWhite is a OneWay converter.");
        }
    }
}