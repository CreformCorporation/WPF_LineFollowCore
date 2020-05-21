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
    class MultiBoolORToVisCollapsedMultiConverter : MarkupExtension, IMultiValueConverter 
    {
        //Constructor for the converter
        private static MultiBoolORToVisCollapsedMultiConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new MultiBoolORToVisCollapsedMultiConverter();
            return _converter;
        }
        public MultiBoolORToVisCollapsedMultiConverter()
        {
            //empty constructor
        }

        //return true if ANY of the arguments are true, else return false
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            foreach (object value in values)
            {
                //if the current value is true
                if ((value is bool) && (bool)value == true)
                {
                    return Visibility.Visible;
                }
            }
            return Visibility.Collapsed;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("MultiBoolORToVisCollapsedMultiConverter is a OneWay converter.");
        }
    }
}
