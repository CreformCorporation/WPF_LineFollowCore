using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIElements
{
    /// <summary>
    /// Interaction logic for NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        #region Dependency Properties

        #region TextBox Font Size

        public double TextBoxFontSize
        {
            get { return (double)GetValue(TextBoxFontSizeProperty); }
            set { SetValue(TextBoxFontSizeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TextBoxFontSizeProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextBoxFontSizeProperty =
            DependencyProperty.Register("TextBoxFontSize", typeof(double), typeof(NumericUpDown), new PropertyMetadata(12.0d));

        #endregion TextBox Font Size

        #region Min

        public int Min
        {
            get { return (int)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TextBoxFontSizeProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(int), typeof(NumericUpDown), new PropertyMetadata(default(int)));

        #endregion Min

        #region Max

        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TextBoxFontSizeProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int), typeof(NumericUpDown), new PropertyMetadata(default(int)));

        #endregion Max

        #region Value

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TextBoxFontSizeProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new PropertyMetadata(default(int)));

        #endregion Value

        #endregion Dependency Properties
        public NumericUpDown()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Up_Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.Value < this.Max)
            {
                this.Value++;
            }
        }

        private void Down_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Value > this.Min)
            {
                this.Value--;
            }
        }
    }
}
