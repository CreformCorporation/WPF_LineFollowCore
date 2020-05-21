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
    public class BoolToTrafficLightColorConverter : MarkupExtension, IValueConverter
    {
        private static readonly Color TrafficRed = new Color() { A = 255, R = 255, G = 175, B = 175 };
        private static readonly Color TrafficGreen = new Color() { A = 255, R = 150, G = 255, B = 150 };

        //Constructor for the converter
        private static BoolToTrafficLightColorConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new BoolToTrafficLightColorConverter();
            return _converter;
        }
        public BoolToTrafficLightColorConverter()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from bool to traffic light color
            bool _value = (bool)value;
            if (_value)
            {
                return TrafficRed;
            }
            else
            {
                return TrafficGreen;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from traffic light image to bool
            Color currentColor = (Color)value;
            //if the current image resource is of the GreenLight 
            if (currentColor.Equals(TrafficGreen))
            {
                return false;//because traffic is not locked
            }
            else//the current image is of the RedLight
            {
                return true;//because traffic is locked
            }
        }
    }
}
