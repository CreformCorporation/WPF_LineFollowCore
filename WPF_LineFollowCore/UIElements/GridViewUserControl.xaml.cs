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
    /// Interaction logic for GridViewUserControl.xaml
    /// </summary>
    public partial class GridViewUserControl : UserControl
    {

        public object GridItemSource
        {
            get { return (double)GetValue(GridItemSourceProperty); }
            set { SetValue(GridItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GridItemSourceProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridItemSourceProperty =
            DependencyProperty.Register("GridItemSource", typeof(object), typeof(GridViewUserControl), new PropertyMetadata(default(object)));

        private TranslateTransform tt = new TranslateTransform();
        public GridViewUserControl()
        {
            InitializeComponent();
            DataContext = this;
            TransformGroup group = new TransformGroup();
            group.Children.Add(tt);
            this.RenderTransform = group;
            this.RenderTransformOrigin = new Point(0.0, 0.0);

            Header.MouseEnter += Header_MouseEnter;
            Header.MouseLeave += Header_MouseLeave;
            Header.MouseLeftButtonDown += Header_MouseLeftButtonDown;
            Header.MouseLeftButtonUp += Header_MouseLeftButtonUp;
            Header.MouseMove += Header_MouseMove;
            Footer.MouseEnter += Footer_MouseEnter;
            Footer.MouseLeave += Footer_MouseLeave;
            Footer.MouseLeftButtonDown += Footer_MouseLeftButtonDown;
            Footer.MouseLeftButtonUp += Footer_MouseLeftButtonUp;
            Footer.MouseMove += Footer_MouseMove;
        }

        void Header_MouseEnter(object sender, MouseEventArgs e)
        {
            //change the cursor to indicate panning
            this.Cursor = Cursors.ScrollAll;
        }
        void Header_MouseLeave(object sender, MouseEventArgs e)
        {
            //restore the cursor
            this.Cursor = Cursors.Arrow;
        }

        void Footer_MouseEnter(object sender, MouseEventArgs e)
        {
            //change the cursor to indicate scaling
            this.Cursor = Cursors.SizeNWSE;
        }
        void Footer_MouseLeave(object sender, MouseEventArgs e)
        {
            //restore the cursor
            this.Cursor = Cursors.Arrow;
        }

        private Point origin;//used to translate the element from it's original position
        private Point start;//stores the position in the window that the mouse is clicked
        void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //get the mouse's current position inside of the Window
            start = e.GetPosition(Application.Current.MainWindow);
            //get the current position of the element
            origin = new Point(tt.X, tt.Y);
            //change the color of the element to indicate it's movement
            this.ControlDataGrid.RowBackground = Brushes.LightGoldenrodYellow;
            //capture the mouse on the element to indicate that it is in use
            Header.CaptureMouse();
        }
        void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if(Header.IsMouseCaptured)
            {
                //calculate the distance that the mouse has been moved since the mouse button was pressed
                Vector v = start - e.GetPosition(Application.Current.MainWindow);
                //translate the element from where it was when the mouse was clicked the same direction and distance that the mouse has moved
                tt.X = origin.X - v.X;
                tt.Y = origin.Y - v.Y;
            }
        }
        void Header_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Header.ReleaseMouseCapture();
            //restore the color of the element
            this.ControlDataGrid.RowBackground = Brushes.White;
        }

        #region Footer Controls(Resizing)

        private Point OriginalWidthandHeight;
        void Footer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //get the mouse's current position inside of the Window
            start = e.GetPosition(Application.Current.MainWindow);
            //get the current size of the element
            OriginalWidthandHeight.X = this.ThisControlGrid.ActualWidth;
            OriginalWidthandHeight.Y = this.ThisControlGrid.ActualHeight;
            //capture the mouse on the element to indicate that it is in use
            Footer.CaptureMouse();
        }
        void Footer_MouseMove(object sender, MouseEventArgs e)
        {
            if (Footer.IsMouseCaptured)
            {
                //calculate the distance that the mouse has been moved since the mouse button was pressed
                Vector v = start - e.GetPosition(Application.Current.MainWindow);
                //resize the element according to the distance the mouse moved
                double newWidth = OriginalWidthandHeight.X - v.X;
                //prevent the width from being to set to less than the minimum width
                if (newWidth < this.ThisControlGrid.MinWidth) newWidth = this.ThisControlGrid.MinWidth;
                double newHeight = OriginalWidthandHeight.Y - v.Y;
                //prevent the Height from being to set to less than the minimum Height
                if (newHeight < this.ThisControlGrid.MinHeight) newHeight = this.ThisControlGrid.MinHeight;
                //apply the new size
                this.ThisControlGrid.Width = newWidth;
                this.ThisControlGrid.Height = newHeight;
            }
        }
        void Footer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Footer.ReleaseMouseCapture();
        }

        #endregion Footer Controls(Resizing)

    }
}
