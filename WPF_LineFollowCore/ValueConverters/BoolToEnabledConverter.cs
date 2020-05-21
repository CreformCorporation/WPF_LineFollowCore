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
    class BoolToEnabledConverter : MarkupExtension, IValueConverter
    {
                //Constructor for the converter
        private static BoolToEnabledConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new BoolToEnabledConverter();
            return _converter;
        }
        public BoolToEnabledConverter()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("The target must be a boolean");

            // Do the conversion from bool to visibility
          //  bool _value = (bool)value;
            //if true, return collapsed
            return (bool)value;// _value ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
            //// Do the conversion from visibility to bool
            //Visibility currentVisibility = (Visibility)value;
            ////if current visibility is collapsed, return true, otherwise false
            //return (currentVisibility == Visibility.Collapsed);
        }

    }
}
