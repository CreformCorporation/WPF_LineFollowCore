using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UIElements
{
    /// <summary>
    /// In addition to the functionality of the ZoomElement class. This class will add the functionality for the element to be 
    /// repositioned by being clicked and dragged with the mouse. 
    /// </summary>
    class MousePositionableZoomElement : ZoomElement
    {
        #region Dependency Properties

        public bool CanReposition
        {
            get { return (bool)GetValue(CanRepositionProperty); }
            set { SetValue(CanRepositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentCanvas.
        public static readonly DependencyProperty CanRepositionProperty =
            DependencyProperty.Register("CanReposition", typeof(bool), typeof(MousePositionableZoomElement), new PropertyMetadata(default(bool), OnCanRepositionChanged));

        private static void OnCanRepositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //currently unused. Only here for possible future use.
        }

        #endregion Dependency Properties

        public MousePositionableZoomElement()
        {
            this.PreviewMouseLeftButtonDown += MousePositionableZoomElement_MouseLeftButtonDown;
            this.MouseLeftButtonUp += MousePositionableZoomElement_MouseLeftButtonUp;
            this.MouseMove += MousePositionableZoomElement_MouseMove;
        }

        private Point initialClickPos = new Point();
        private Vector delta = new Vector();
        private bool mouseDown = false;

        void MousePositionableZoomElement_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Console.WriteLine("Zoom Element CLICKED!");
            
            //ensure we can reposition this element
            if (!CanReposition) return;
            Console.WriteLine("CAN REPOSITION!");
            //record the position of the mouseclick
            initialClickPos = e.GetPosition(ParentCanvas);

            if (Mouse.Capture(this, CaptureMode.SubTree))
            { 
                Console.WriteLine("Mouse captured by label!");
            }
            else
            {
                Console.WriteLine("Label could NOT capture mouse!");
            }
            
            //lastly, set mousedown to true
            mouseDown = true;
        }

        void MousePositionableZoomElement_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //Console.WriteLine("MOVED!");//DEBUG
            //only calculate the movement if the left mouse button is down
            if (!mouseDown) return;
            if (this.IsMouseCaptured)
            {
                e.Handled = true;
                //get the current mouse position
                Point currentMousePos = e.GetPosition(ParentCanvas);
                //calculate how far the mouse has moved
                delta = currentMousePos - initialClickPos;
                //figure out the x percentage moved
                float xPrcnt = (float)(delta.X / ParentWidth);
                //figure out the y percentage moved
                float yPrcnt = (float)(delta.Y / ParentHeight);
                //Console.WriteLine("xPrcnt: " + xPrcnt);//DEBUG
                //Console.WriteLine("yPrcnt: " + yPrcnt);//DEBUG
                if (Math.Abs(xPrcnt) > 0 || Math.Abs(yPrcnt) > 0)
                {
                    //Add them to the current X and Y percentages
                    XLoc += xPrcnt;
                    YLoc += yPrcnt;
                    //recalculate the element position
                    ReinitializePosition(null, null);
                    //update the initial clicked point to the current mouse position
                    initialClickPos = currentMousePos;
                }
            }
        }

        void MousePositionableZoomElement_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Console.WriteLine("MOUSE RELEASED on Zoom Element!");
            //first, release the mousedown variable
            mouseDown = false;
            if (this.IsMouseCaptured)
            {
                this.ReleaseMouseCapture();
                e.Handled = true;
            }
        }
        

        
    }
}
