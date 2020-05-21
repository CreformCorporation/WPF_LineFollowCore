using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueConverters
{
    public class MultiplierConverter : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static MultiplierConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new MultiplierConverter();
            return _converter;
        }

        public MultiplierConverter()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //use a var here because it may be a string or double value depending on the UIElement
            var dblValue = 1.0;
            //the value is the item being change. ie. Width
            //check the type of the value passed in and store it in our double
            if (value is double)
                dblValue = (double)value;
            else if (!(value is string) || !double.TryParse((string)value, out dblValue))
                return null;
            
            //The parameter is the multiplication value. ie. 0.5
            //it might also be a double or a string. So we need to be sure to convert it to a double if it isn't already
            var dblParam = 1.0;
            if (parameter is double)
                dblParam = (double)parameter;
            else if (!(parameter is string) || !double.TryParse((string)parameter, out dblParam))
                return null;

            //return the values multiplied together
            return dblValue * dblParam;
        }

        //do not allow a backwards conversion
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
