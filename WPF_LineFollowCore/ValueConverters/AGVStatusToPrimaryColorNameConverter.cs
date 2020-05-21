using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
namespace ValueConverters
{
    class AGVStatusToPrimaryColorNameConverter : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static AGVStatusToPrimaryColorNameConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new AGVStatusToPrimaryColorNameConverter();
            return _converter;
        }
        public AGVStatusToPrimaryColorNameConverter()
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
            else if (_value.HasFlag(Constants.Constants.AGVStatus.Faulted)) return "Red";
            //Laser Stopped: Primary Yellow, Secondary Yellow
            else if (_value.HasFlag(Constants.Constants.AGVStatus.LaserStopped)) return "Yellow";
            //Stopped: Primary Red, Secondary Red
            else if (_value.HasFlag(Constants.Constants.AGVStatus.Stopped)) return "Red";
            //Moving: Primary Green, Secondary Light Green
            else if (_value.HasFlag(Constants.Constants.AGVStatus.Moving)) return "Green";
            //Low Voltage: Primary Red, Secondary Yellow
            else if (_value.HasFlag(Constants.Constants.AGVStatus.LowVoltage)) return "Red";
            
            //no status set
            else return "White";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("AGVStatusToPrimaryColorNameConverter is a OneWay converter.");
        }
    }
}
