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
    public class ZoomContainer : Border
    {
        #region Dependency Properties

        /// <summary>
        /// Used to allow other elements to see what the ZoomContainer's current ScaleTransform values are
        /// </summary>
        #region ScaleTransform Values

        public double ScaleTransformX
        {
            get { return (double)GetValue(ScaleTransformXProperty); }
            set 
            {
                SetValue(ScaleTransformXProperty, value);
            }

        }

        // Using a DependencyProperty as the backing store for ScaleTransform.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleTransformXProperty =
            DependencyProperty.Register("ScaleTransformX", typeof(double), typeof(ZoomContainer), new PropertyMetadata(1.0d, OnScaleXValueChanged));

        public double ScaleTransformY
        {
            get { return (double)GetValue(ScaleTransformYProperty); }
            set 
            { 
                SetValue(ScaleTransformYProperty, value); 
            }
        }

        // Using a DependencyProperty as the backing store for ScaleTransform.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleTransformYProperty =
            DependencyProperty.Register("ScaleTransformY", typeof(double), typeof(ZoomContainer), new PropertyMetadata(1.0d, OnScaleYValueChanged));

        private static void OnScaleXValueChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ZoomContainer thisElement = (ZoomContainer)source;
            //update Actual Transform
            thisElement.UpdatePrivateScaleValues(thisElement.ScaleTransformX);
        }

        private static void OnScaleYValueChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ZoomContainer thisElement = (ZoomContainer)source;
            //update Actual Transform
            thisElement.UpdatePrivateScaleValues(thisElement.ScaleTransformY);
        }

        #endregion ScaleTransform Values

        /// <summary>
        /// Used to allow other elements to see what the ZoomContainer's current ScaleTransform values are
        /// </summary>
        #region TranslateTransform Values

        public double TranslateTransformX
        {
            get { return (double)GetValue(TranslateTransformXProperty); }
            set
            {
                SetValue(TranslateTransformXProperty, value);
            }

        }

        // Using a DependencyProperty as the backing store for ScaleTransform.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TranslateTransformXProperty =
            DependencyProperty.Register("TranslateTransformX", typeof(double), typeof(ZoomContainer), new PropertyMetadata(0.0d, OnTranslationXValueChanged));

        public double TranslateTransformY
        {
            get { return (double)GetValue(TranslateTransformYProperty); }
            set
            {
                SetValue(TranslateTransformYProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ScaleTransform.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TranslateTransformYProperty =
            DependencyProperty.Register("TranslateTransformY", typeof(double), typeof(ZoomContainer), new PropertyMetadata(0.0d, OnTranslationYValueChanged));


        private static void OnTranslationXValueChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ZoomContainer thisElement = (ZoomContainer)source;
            //update Actual Transform
            thisElement.UpdatePrivateXTranslationValue(thisElement.TranslateTransformX);
        }

        private static void OnTranslationYValueChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ZoomContainer thisElement = (ZoomContainer)source;
            //update Actual Transform
            thisElement.UpdatePrivateYTranslationValue(thisElement.TranslateTransformY);
        }

        #endregion TranslateTransform Values

        #endregion Dependency Properties

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

        /// <summary>
        /// Goes through the transform group of the passed element and get the ScaleTransform contained in it.
        /// </summary>
        /// <param name="element">The UIElement whose 'RenderTransform' property has been set to a 'TransformGroup' that contains a 'ScaleTransform'</param>
        /// <returns>Returns the first instance of a ScaleTransform found in the TransformGroup in the UIElement.</returns>
        private ScaleTransform GetScaleTransform(UIElement element)
        {
            return (ScaleTransform)((TransformGroup)element.RenderTransform)
              .Children.First(tr => tr is ScaleTransform);
        }

        //the child element that will be manipulated
        private UIElement childElement = null;
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
                ScaleTransform st = new ScaleTransform();
                group.Children.Add(st);
                TranslateTransform tt = new TranslateTransform();
                group.Children.Add(tt);
                childElement.RenderTransform = group;
                childElement.RenderTransformOrigin = new Point(0.0, 0.0);
                this.MouseWheel += child_MouseWheel;
                this.MouseLeftButtonDown += child_MouseLeftButtonDown;
                this.PreviewMouseLeftButtonUp += child_MouseLeftButtonUp;
                this.MouseMove += child_MouseMove;
                this.MouseRightButtonDown += new MouseButtonEventHandler(child_PreviewMouseRightButtonDown);
                //Set an event to fire and position the element after all of the dependency values have been set, but before the ZoomContainer is rendered.
                this.Loaded += SetInitialPositionAndScale;
            }
        }

        private void SetInitialPositionAndScale(object sender, RoutedEventArgs e)
        {
            //Set the initial scale based on the parent's scale
            //get the scale and translate transforms from the element
            var st = GetScaleTransform(childElement);
            st.ScaleX = ScaleTransformX;
            st.ScaleY = ScaleTransformY;

            //set initial translation
            TranslateTransform tt = GetTranslateTransform(childElement);
            tt.X = TranslateTransformX;
            tt.Y = TranslateTransformY;


        }

        public void Reset()
        {
            if (childElement != null)
            {
                //reset zoom
                ScaleTransform st = GetScaleTransform(childElement);
                st.ScaleX = 1.0;
                st.ScaleY = 1.0;

                //reset pan
                TranslateTransform tt = GetTranslateTransform(childElement);
                tt.X = 0.0;
                tt.Y = 0.0;

                UpdatePublicScaleValues(st);
                UpdatePublicTranslationValues(tt);
            }
        }

        private void UpdatePrivateScaleValues(double scale)
        {
            if (childElement != null)
            {
                ScaleTransform st = GetScaleTransform(childElement);
                st.ScaleX = scale;
                st.ScaleY = scale;
            }
        }
        private void UpdatePublicScaleValues(ScaleTransform currentST)
        {
            ScaleTransformX = currentST.ScaleX;
            ScaleTransformY = currentST.ScaleY;
            //Console.WriteLine("ScaleTransformX: " + ScaleTransformX);
            //Console.WriteLine("ScaleTransformY: " + ScaleTransformY);
        }

        private void UpdatePrivateXTranslationValue(double xTranslation)
        {
            if (childElement != null)
            {
                TranslateTransform tt = GetTranslateTransform(childElement);
                tt.X = xTranslation;
            }
        }
        private void UpdatePrivateYTranslationValue(double yTranslation)
        {
            if (childElement != null)
            {
                TranslateTransform tt = GetTranslateTransform(childElement);
                tt.Y = yTranslation;
            }
        }
        private void UpdatePublicTranslationValues(TranslateTransform currentTT)
        {
            TranslateTransformX = currentTT.X;
            TranslateTransformY = currentTT.Y;
        }

        #region Child Events

        private void child_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (childElement != null)
            {
                //get the scale and translate transforms from the element
                var st = GetScaleTransform(childElement);
                var tt = GetTranslateTransform(childElement);

                //get the zoom speed based on the direction of the scroll, negative if scrolling back and positive if forward
                double zoom = e.Delta > 0 ? .05 : -.05;

                //Ensure that we don't zoom too far. This prevents zooming to nothing and inverting the image
                if (!(e.Delta > 0) && (st.ScaleX < .3 || st.ScaleY < .3))
                {
                    return;
                }

                //get the current mouse position to be used for the zoom
                Point relative = e.GetPosition(childElement);
                //get the absolute x and y before the zoom is applied to the child
                /*
                double abosuluteX = relative.X * st.ScaleX + tt.X;
                double abosuluteY = relative.Y * st.ScaleY + tt.Y;
                */

                double abosuluteX = relative.X * ScaleTransformX + tt.X;
                double abosuluteY = relative.Y * ScaleTransformY + tt.Y;

                //apply transformation
                //Note that this zoom is relative to the (0,0) position of the element and the element will have to be translated using the translate transform
                /*
                st.ScaleX += zoom;
                st.ScaleY += zoom;
                 */
                ScaleTransformX += zoom;
                ScaleTransformY += zoom;

                //translate image to correct position. Performs the zoom relative to the mouse position.
                /*
                tt.X = abosuluteX - relative.X * st.ScaleX;
                tt.Y = abosuluteY - relative.Y * st.ScaleY;
                */
                tt.X = abosuluteX - relative.X * ScaleTransformX;
                tt.Y = abosuluteY - relative.Y * ScaleTransformY;

                UpdatePublicScaleValues(st);
                //updating public already updates private
                //UpdatePrivateScaleValues(ScaleTransformX);

                
                UpdatePublicTranslationValues(tt);
                //updating public already updates private
                //UpdatePrivateXTranslationValue(tt.X);
                //UpdatePrivateXTranslationValue(tt.Y);
            }
        }

        private void child_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (childElement != null)
            {
                //Console.WriteLine("MouseDown in zoomContainer.");//DEBUG
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
                //Console.WriteLine("MouseUp in zoomContainer.");//DEBUG
                //release the mouse to indicate that the panning is finished
                childElement.ReleaseMouseCapture();
                //restore the cursor to the default cursor
                this.Cursor = Cursors.Arrow;
            }
        }

        void child_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //resest the zoom to the default state
            this.Reset();
        }

        private void child_MouseMove(object sender, MouseEventArgs e)
        {
            if (childElement != null)
            {
                
                //if the mouse button is being held down
                if (childElement.IsMouseCaptured)
                {
                    //Console.WriteLine("MouseMove in zoomContainer.");//DEBUG
                    //get the translation transformation out of the child element
                    var tt = GetTranslateTransform(childElement);
                    //calculate the distance that the mouse has been moved since the mouse button was pressed
                    Vector v = start - e.GetPosition(this);
                    //translate the child element from where it was when the mouse was clicked the same direction and distance that the mouse has moved
                    tt.X = origin.X - v.X;
                    tt.Y = origin.Y - v.Y;

                    UpdatePublicTranslationValues(tt);
                    //Console.WriteLine("TTX: " + tt.X);
                    //Console.WriteLine("TTY: " + tt.Y);
                }
            }
        }

        #endregion
    }
}
