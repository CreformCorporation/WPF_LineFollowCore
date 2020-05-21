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
    public class PositionableContainer : Border
    {
        public PositionableContainer()
        {

        }

        //Child property. This is the element that is contained within this container.
        private UIElement childElement = null;
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
                this.MouseLeftButtonDown += LeftMouseButtonDown;
                this.MouseLeftButtonUp += LeftMouseButtonUp;
                this.MouseMove += MouseMoved;
            }
        }

        #region Repositioning Code

        private Point origin;
        private Point start;
        private bool mouseHeld = false;

        //Begin to move the element
        private void LeftMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (childElement != null)
            {
                //get the translate transform
                TranslateTransform tt = (childElement.RenderTransform as TransformGroup).Children[0] as TranslateTransform;
                //get the mouse's current position inside of the window
                start = e.GetPosition(this);
                //get the current position
                origin = new Point(tt.X, tt.Y);
                //change the cursor to a hand to indicate panning
                this.Cursor = Cursors.Hand;
                this.mouseHeld = true;
            }
        }
        //Release the element in the new position
        private void LeftMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (childElement != null)
            {
                this.mouseHeld = false;
                //restore the cursor to the default cursor
                this.Cursor = Cursors.Arrow;
            }
        }
        private void MouseMoved(object sender, MouseEventArgs e)
        {
            if (childElement != null)
            {
                if (this.mouseHeld)
                {
                    //perform translation
                    //get the translation transformation
                    TranslateTransform tt = (childElement.RenderTransform as TransformGroup).Children[0] as TranslateTransform;
                    //calculate the distance that the mouse has been moved since the mouse button was pressed
                    Vector v = start - e.GetPosition(this);
                    //translate the element from where it was when the mouse was clicked the same direction and distance that the mouse has moved
                    tt.X = origin.X - v.X;
                    tt.Y = origin.Y - v.Y;
                }
            }
        }
        #endregion Repositioning Code
    }
}
