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
    public class BoolToVisCollapsedConverter : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static BoolToVisCollapsedConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new BoolToVisCollapsedConverter();
            return _converter;
        }
        public BoolToVisCollapsedConverter()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from bool to visibility
            bool _value = (bool)value;
            return _value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from visibility to bool
            Visibility currentVisibility = (Visibility)value;
            //if current visibility is visible, return true, otherwise false
            return (currentVisibility == Visibility.Visible);
        }
    }
}
