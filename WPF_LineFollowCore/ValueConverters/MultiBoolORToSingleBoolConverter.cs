using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueConverters
{
    class MultiBoolORToSingleBoolConverter : MarkupExtension, IMultiValueConverter 
    {
        //Constructor for the converter
        private static MultiBoolORToSingleBoolConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new MultiBoolORToSingleBoolConverter();
            return _converter;
        }
        public MultiBoolORToSingleBoolConverter()
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
                    return true;
                }
            }
            return false;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("MultiBoolORToSingleBoolConverter is a OneWay converter.");
        }
    }
}
