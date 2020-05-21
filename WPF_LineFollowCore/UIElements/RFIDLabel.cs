using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UIElements
{
    class RFIDLabel : Label
    {
        /// <summary>
        /// Constructor. Fires before the label is initialized or any of the dependency properties have their values. Sets up the initial layout of the label. 
        /// </summary>
        public RFIDLabel()
        {
            this.BorderBrush = Brushes.White;
            this.BorderThickness = new Thickness(0.5);
            this.Foreground = Brushes.White;
            //this.Background = Brushes.Black;
            //this.FontSize = 12;
            this.HorizontalContentAlignment = HorizontalAlignment.Center;
            this.Padding = new Thickness(1, 0, 1, 0);
        }

    }
}
