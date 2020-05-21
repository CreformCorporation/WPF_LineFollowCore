using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueConverters
{
    class MultiBoolANDToSingleBoolConverter : MarkupExtension, IMultiValueConverter 
    {
        //Constructor for the converter
        private static MultiBoolANDToSingleBoolConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new MultiBoolANDToSingleBoolConverter();
            return _converter;
        }
        public MultiBoolANDToSingleBoolConverter()
        {
            //empty constructor
        }

        //return true if ALL of the arguments are true, else return false
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            foreach (object value in values)
            {
                //if the current value is false
                if ((value is bool) && (bool)value == false)
                {
                    return false;
                }
            }
            return true;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("MultiBoolANDToSingleBoolConverter is a OneWay converter.");
        }
    }
}
