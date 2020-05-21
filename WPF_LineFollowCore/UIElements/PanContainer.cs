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
    class PanContainer : Border
    {
        //the child element that will be manipulated
        private UIElement childElement = null;

        private Point origin;
        private Point start;

        /// <summary>
        /// Goes through the transform group of the passed element and get the TranslateTransform contained in it.
        /// </summary>
        /// <param name="element">The UIElement whose 'RenderTransform' property has been set to a 'TransformGroup' that contains a 'TranslateTransform'</param>
        /// <returns>Returns the first instance of a translate transform found in the TransformGroup in the UIElement.</returns>
        private TranslateTransform GetTranslateTransform(UIElement element)
        {
            return (TranslateTransform)((TransformGroup)element.RenderTransform).Children.First(tr => tr is TranslateTransform);
        }

        //Public Child property
        public override UIElement Child
        {
            get { return base.Child; }
            set
            {
                if (value != null && value != this.Child)
                    this.Initialize(value);
                base.Child = value;
            }
        }

        public void Initialize(UIElement element)
        {
            this.childElement = element;
            if (childElement != null)
            {
                TransformGroup group = new TransformGroup();
                TranslateTransform tt = new TranslateTransform();
                group.Children.Add(tt);
                childElement.RenderTransform = group;
                childElement.RenderTransformOrigin = new Point(0.0, 0.0);
                this.PreviewMouseLeftButtonDown += child_MouseLeftButtonDown;
                //this.MouseLeftButtonDown += child_MouseLeftButtonDown;
                this.MouseLeftButtonUp += child_MouseLeftButtonUp;
                this.MouseMove += child_MouseMove;
            }
        }

        #region Child Events

        private void child_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (childElement != null)
            {
                //get the translate transform
                var tt = GetTranslateTransform(childElement);
                //get the mouse's current position inside of the ZoomContainer
                start = e.GetPosition(this);
                //get the current position of the child element
                origin = new Point(tt.X, tt.Y);
                //change the cursor to a hand to indicate panning
                this.Cursor = Cursors.Hand;
                //capture the mouse on the child element to indicate that it is in use
                childElement.CaptureMouse();
            }
        }

        private void child_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (childElement != null)
            {
                //release the mouse to indicate that the panning is finished
                childElement.ReleaseMouseCapture();
                //restore the cursor to the default cursor
                this.Cursor = Cursors.Arrow;
            }
        }

        private void child_MouseMove(object sender, MouseEventArgs e)
        {
            if (childElement != null)
            {
                //if the mouse button is being held down
                if (childElement.IsMouseCaptured)
                {
                    //get the translation transformation out of the child element
                    var tt = GetTranslateTransform(childElement);
                    //calculate the distance that the mouse has been moved since the mouse button was pressed
                    Vector v = start - e.GetPosition(this);
                    //translate the child element from where it was when the mouse was clicked the same direction and distance that the mouse has moved
                    tt.X = origin.X - v.X;
                    tt.Y = origin.Y - v.Y;
                }
            }
        }

        #endregion
    }
}
