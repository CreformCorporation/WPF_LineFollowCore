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
    public class AGVTypeToImageConverter : MarkupExtension, IValueConverter
    {
        //Constructor for the converter
        private static AGVTypeToImageConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new AGVTypeToImageConverter();
            return _converter;
        }
        public AGVTypeToImageConverter()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from AGV type to image
            Constants.Constants.AGVType _value = (Constants.Constants.AGVType)value;

            switch ((int)_value)
            {
                case (int)Constants.Constants.AGVType.NSI:
                    //Return Mouse image
                    return Application.Current.FindResource("AGV_Image");

                default:
                    //TODO: Log error. An AGVType was not specified or an unknown AGVType was specified.
                    Console.WriteLine("An AGVType was not specified or an unknown AGVType was specified in the AGV Type to Image Converter.");
                    return Application.Current.FindResource("UnknownAGVImage");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("AGVTypeToImageConverter is a OneWay converter.");
        }
    }
}
