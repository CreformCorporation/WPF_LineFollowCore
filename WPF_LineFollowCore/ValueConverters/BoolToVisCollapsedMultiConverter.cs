using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueConverters
{
    class BoolToVisCollapsedMultiConverter : MarkupExtension, IMultiValueConverter 
    {
        //Constructor for the converter
        private static BoolToVisCollapsedMultiConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new BoolToVisCollapsedMultiConverter();
            return _converter;
        }
        public BoolToVisCollapsedMultiConverter()
        {
            //empty constructor
        }

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            foreach (object value in values)
            {
                if ((value is bool) && (bool)value == false)
                {
                    return Visibility.Collapsed;
                }
            }
            return Visibility.Visible;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("BoolToVisCollapsedMultiConverter is a OneWay converter.");
        }
    }
}
