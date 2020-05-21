using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace ValueConverters
{
    class BoolToRedOrBlack : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static BoolToRedOrBlack _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new BoolToRedOrBlack();
            return _converter;
        }
        public BoolToRedOrBlack()
        {
            //empty constructor
        }
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from bool to color
            bool _value = (bool)value;
            if (_value)
            {
                return Brushes.Red;
            }
            else
            {
                return Brushes.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from color to bool
            Brush currentColor = (Brush)value;
            //if color is black 
            if (currentColor.Equals(Brushes.Black))
            {
                return false;//because traffic is not locked
            }
            else//the current color is Red
            {
                return true;//because traffic is locked
            }
        }
    }
}
