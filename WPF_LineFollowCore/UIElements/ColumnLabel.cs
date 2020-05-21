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
    class ColumnLabel : Label
    {
        public ColumnLabel()
        {
            this.BorderBrush = Brushes.White;
            this.BorderThickness = new Thickness(1);
            this.Foreground = Brushes.Black;
            this.Background = Brushes.Orange;
            this.FontSize = 15;
            this.FontWeight = FontWeights.Bold;
            this.Padding = new Thickness(1, 0, 1, 0);
        }
    }
}
