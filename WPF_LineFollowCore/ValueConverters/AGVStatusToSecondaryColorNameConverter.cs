
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueConverters
{
    class AGVStatusToSecondaryColorNameConverter : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static AGVStatusToSecondaryColorNameConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new AGVStatusToSecondaryColorNameConverter();
            return _converter;
        }
        public AGVStatusToSecondaryColorNameConverter()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from AGV Status to Color Name
            Constants.Constants.AGVStatus _value = (Constants.Constants.AGVStatus)value;

            //Disconnected: Primary Purple, Secondary Purple
            if (_value.HasFlag(Constants.Constants.AGVStatus.Disconnected)) return "Purple";
            //Faulted: Primary Red, Secondary DarkSalmon
            else if (_value.HasFlag(Constants.Constants.AGVStatus.Faulted)) return "DarkSalmon";
            //Laser Stopped: Primary Yellow, Secondary Yellow
            else if (_value.HasFlag(Constants.Constants.AGVStatus.LaserStopped)) return "Yellow";
            //Stopped: Primary Red, Secondary Red
            else if (_value.HasFlag(Constants.Constants.AGVStatus.Stopped)) return "Red";
            //Moving: Primary Green, Secondary Light Green
            else if (_value.HasFlag(Constants.Constants.AGVStatus.Moving)) return "LightGreen";
            //Low Voltage: Primary Red, Secondary Yellow
            else if (_value.HasFlag(Constants.Constants.AGVStatus.LowVoltage)) return "Yellow";
            
            //no status set
            else return "White";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("AGVStatusToSecondaryColorNameConverter is a OneWay converter.");
        }
    }
}
