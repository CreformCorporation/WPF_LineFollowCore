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
    /************CURRENTLY UNUSED**************/
    class ZoomLabel : Label
    {
        #region Dependency Properties

        #region X and Y Location

        public double XLoc
        {
            get { return (double)GetValue(XLocProperty); }
            set { SetValue(XLocProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XLocation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XLocProperty =
            DependencyProperty.Register("XLoc", typeof(double), typeof(ZoomLabel), new PropertyMetadata(default(double)));

        public double YLoc
        {
            get { return (double)GetValue(YLocProperty); }
            set { SetValue(YLocProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YLocation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YLocProperty =
            DependencyProperty.Register("YLoc", typeof(double), typeof(ZoomLabel), new PropertyMetadata(default(double)));

        #endregion X and Y Location

        #region Parent Width and Height

        public double ParentWidth
        {
            get { return (double)GetValue(ParentWidthProperty); }
            set { SetValue(ParentWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentWidth.
        public static readonly DependencyProperty ParentWidthProperty =
            DependencyProperty.Register("ParentWidth", typeof(double), typeof(ZoomLabel), new PropertyMetadata(default(double), OnParentWidthAndHeightPropertyChanged));

        public double ParentHeight
        {
            get { return (double)GetValue(ParentHeightProperty); }
            set { SetValue(ParentHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentHeight.
        public static readonly DependencyProperty ParentHeightProperty =
            DependencyProperty.Register("ParentHeight", typeof(double), typeof(ZoomLabel), new PropertyMetadata(default(double), OnParentWidthAndHeightPropertyChanged));

        #endregion Parent Width and Height

        #region Parent X and Y Scale

        public double ParentScaleX
        {
            get { return (double)GetValue(ParentScaleXProperty); }
            set { SetValue(ParentScaleXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentScale.
        public static readonly DependencyProperty ParentScaleXProperty =
            DependencyProperty.Register("ParentScaleX", typeof(double), typeof(ZoomLabel), new PropertyMetadata((double)1.0, OnParentScaleXPropertyChanged));

        public double ParentScaleY
        {
            get { return (double)GetValue(ParentScaleYProperty); }
            set { SetValue(ParentScaleYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentScale.
        public static readonly DependencyProperty ParentScaleYProperty =
            DependencyProperty.Register("ParentScaleY", typeof(double), typeof(ZoomLabel), new PropertyMetadata((double)1.0, OnParentScaleYPropertyChanged));

        #endregion Parent X and Y Scale

        #endregion Dependency Properties

        #region Dependency Property Events

        #region OnParentScaleChanged

        private static void OnParentScaleXPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ZoomLabel thisLabel = (ZoomLabel)source;

            if (thisLabel.ParentScaleX != 0)
            {
                double tempScale = 1.0 / thisLabel.ParentScaleX;
                thisLabel.SetScaleX(tempScale);
            }
        }

        private static void OnParentScaleYPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            // Put some update logic here...
            ZoomLabel thisLabel = (ZoomLabel)source;

            if (thisLabel.ParentScaleY != 0)
            {
                double tempScale = 1.0 / thisLabel.ParentScaleY;
                thisLabel.SetScaleY(tempScale);
            }
        }

        #endregion OnParentScaleChanged

        #region OnParentSizeChanged

        /// <summary>
        /// When the canvas size changes. ie on window maximization, recalculates the position of the label in the canvas
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnParentWidthAndHeightPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ZoomLabel thisLabel = (ZoomLabel)source;//get this label
            thisLabel.ReinitializePosition(null, null);//update its margins based on the new size
        }

        #endregion OnParentSizeChanged

        #endregion Dependency Property Events

        #region Constructor

        /// <summary>
        /// Constructor. Fires before the label is initialized or any of the dependency properties have their values. Sets up the initial layout of the label and prepares the transform group. 
        /// </summary>
        public ZoomLabel()
        {
            #region Set Up Scaling and Translating

            //create a transform group and put a scale and translate transform within it
            TransformGroup tg = new TransformGroup();
            ScaleTransform st = new ScaleTransform();
            tg.Children.Add(st);
            TranslateTransform tt = new TranslateTransform();
            tg.Children.Add(tt);
            this.RenderTransform = tg;
            this.RenderTransformOrigin = new Point(0.5, 0.5);

            #endregion Set Up Scaling and Translating

            //set width and height to 'auto' using double.NaN
            this.Width = double.NaN;
            this.Height = double.NaN;

            //set the alignment style of the zoomlabel to top and left
            this.VerticalAlignment = VerticalAlignment.Top;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

            //Set an event to fire and position the element after all of the dependency values have been set, but before the label is rendered.
            this.Initialized += SetInitialPositionAndScale;
        }

        #endregion Constructor

        #region Local Methods

        /// <summary>
        /// fires just before the label is rendered. We set the object location and scale here, based on the values in the dependency properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetInitialPositionAndScale(object sender, EventArgs e)
        {
            //sets the position of the zoomlabel to a percentage of the width and height of the parent
            //where Xloc and Yloc are values between 0 and 1 and parentwidth and parentheight are the actual size of the parent element
            this.Margin = new Thickness((XLoc * ParentWidth) - (this.ActualWidth / 2), (YLoc * ParentHeight) - (this.ActualHeight / 2), 0, 0);

            //Set the initial scale based on the parent's scale
            if (ParentScaleX != 0) SetScaleX(1 / ParentScaleX);
            if (ParentScaleY != 0) SetScaleY(1 / ParentScaleY);
        }
        public void ReinitializePosition(object sender, EventArgs e)
        {
            this.Margin = new Thickness((XLoc * ParentWidth) - (this.ActualWidth/2), (YLoc * ParentHeight) - (this.ActualHeight/2), 0, 0);
        }
        public void SetScaleX(double xscalar)
        {
            try
            {
                ScaleTransform thisScale = (ScaleTransform)((TransformGroup)this.RenderTransform).Children.First(tr => tr is ScaleTransform);
                if (!thisScale.IsFrozen)
                {
                    thisScale.ScaleX = xscalar;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot set XScale on ZoomLabel");
                Console.WriteLine(e.StackTrace);
            }

        }
        public void SetScaleY(double yscalar)
        {
            try
            {
                ScaleTransform thisScale = (ScaleTransform)((TransformGroup)this.RenderTransform).Children.First(tr => tr is ScaleTransform);
                if (!thisScale.IsFrozen)
                {
                    thisScale.ScaleY = yscalar;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot set YScale on ZoomLabel");
                Console.WriteLine(e.StackTrace);
            }
        }

        #endregion Local Methods
    }
}
