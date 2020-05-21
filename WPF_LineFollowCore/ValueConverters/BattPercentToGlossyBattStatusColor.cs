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
    public class BattPercentToGlossyBattStatusColor : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static BattPercentToGlossyBattStatusColor _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new BattPercentToGlossyBattStatusColor();
            return _converter;
        }
        public BattPercentToGlossyBattStatusColor()
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
                //White
                return Brushes.White;
            }
            if(_value > 50)
            {
                //green
                return Brushes.Green;
            }
            if(_value > 25)
            {
                //yellow
                return Brushes.Gold;
            }
            else//below 25%
            {
                //red
                return Brushes.DeepPink;
            }
        }

        //do not allow a backwards conversion
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
