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
    public class BoolToTrafficLockConverter : MarkupExtension, IValueConverter
    {

        //Constructor for the converter
        private static BoolToTrafficLockConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new BoolToTrafficLockConverter();
            return _converter;
        }
        public BoolToTrafficLockConverter()
        {
            //empty constructor
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from bool to traffic light image
            bool _value = (bool)value;
            if(_value)
            {
                return Application.Current.FindResource("TrafficLightRed");
            }
            else
            {
                return Application.Current.FindResource("TrafficLightGreen");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do the conversion from traffic light image to bool
            ImageBrush currentImage = (ImageBrush)value;
            //if the current image resource is of the GreenLight 
            if (String.Equals(currentImage.ImageSource, ((ImageBrush)Application.Current.FindResource("TrafficLightGreen")).ImageSource))
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
