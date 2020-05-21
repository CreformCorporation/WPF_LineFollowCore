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
    class BattPercentToFlatBattStatusColor: MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static BattPercentToFlatBattStatusColor _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new BattPercentToFlatBattStatusColor();
            return _converter;
        }
        public BattPercentToFlatBattStatusColor()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from battery percentage to visibility
            int _value = (int)value;
            //if in the charging range
            if (_value >= 100)
            {
                //Blue color
                return new SolidColorBrush(Color.FromRgb(52, 152, 219));
            }
            if(_value > 75)
            {
                //green
                return Brushes.LightGreen;
            }
            if(_value > 25)
            {
                //yellow
                return Brushes.Gold;
                //return new SolidColorBrush(Color.FromRgb(241, 196, 15));
            }
            else//below 25%
            {
                //red
                return Brushes.Red;
                //return new SolidColorBrush(Color.FromRgb(192, 57, 43));
            }
        }

        //do not allow a backwards conversion
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
