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
    public class ZoomElement : ContentControl
    {
        #region Dependency Properties

        public Canvas ParentCanvas
        {
            get { return (Canvas)GetValue(ParentCanvasProperty); }
            set 
            { 
                if((value != null) && (this.ParentCanvas == null))
                {
                    
                    //Set up the parent sizechanged event
                    this.ParentCanvas.SizeChanged += ReinitializePosition;
                }
                SetValue(ParentCanvasProperty, value); 
            }
        }

        // Using a DependencyProperty as the backing store for ParentCanvas.
        public static readonly DependencyProperty ParentCanvasProperty =
            DependencyProperty.Register("ParentCanvas", typeof(Canvas), typeof(ZoomElement), new PropertyMetadata(default(Canvas), OnParentParentCanvasChanged));

        private static void OnParentParentCanvasChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //currently unused. Only here for possible future use.
        }

        #region X and Y Location

        public float XLoc
        {
            get { return (float)GetValue(XLocProperty); }
            set { SetValue(XLocProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XLocation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XLocProperty =
            DependencyProperty.Register("XLoc", typeof(float), typeof(ZoomElement), new PropertyMetadata(default(float), OnXLocationPropertyChanged));

        public float YLoc
        {
            get { return (float)GetValue(YLocProperty); }
            set { SetValue(YLocProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YLocation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YLocProperty =
            DependencyProperty.Register("YLoc", typeof(float), typeof(ZoomElement), new PropertyMetadata(default(float), OnYLocationPropertyChanged));

        #endregion X and Y Location

        #region Parent Width and Height

        public double ParentWidth
        {
            get { return (double)GetValue(ParentWidthProperty); }
            set { SetValue(ParentWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentWidth.
        public static readonly DependencyProperty ParentWidthProperty =
            DependencyProperty.Register("ParentWidth", typeof(double), typeof(ZoomElement), new PropertyMetadata(default(double), OnParentWidthAndHeightPropertyChanged));

        public double ParentHeight
        {
            get { return (double)GetValue(ParentHeightProperty); }
            set { SetValue(ParentHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentHeight.
        public static readonly DependencyProperty ParentHeightProperty =
            DependencyProperty.Register("ParentHeight", typeof(double), typeof(ZoomElement), new PropertyMetadata(default(double), OnParentWidthAndHeightPropertyChanged));

        #endregion Parent Width and Height

        #region Parent X and Y Scale

        public double ParentScaleX
        {
            get { return (double)GetValue(ParentScaleXProperty); }
            set { SetValue(ParentScaleXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentScale.
        public static readonly DependencyProperty ParentScaleXProperty =
            DependencyProperty.Register("ParentScaleX", typeof(double), typeof(ZoomElement), new PropertyMetadata((double)1.0, OnParentScaleXPropertyChanged));

        public double ParentScaleY
        {
            get { return (double)GetValue(ParentScaleYProperty); }
            set { SetValue(ParentScaleYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentScale.
        public static readonly DependencyProperty ParentScaleYProperty =
            DependencyProperty.Register("ParentScaleY", typeof(double), typeof(ZoomElement), new PropertyMetadata((double)1.0, OnParentScaleYPropertyChanged));

        #endregion Parent X and Y Scale

        #region This Element's X and Y Scale

        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentScale.
        public static readonly DependencyProperty ScaleProperty =
            DependencyProperty.Register("Scale", typeof(double), typeof(ZoomElement), new PropertyMetadata((double)1.0, OnScaleChanged));

        #endregion This Element's X and Y Scale

        #endregion Dependency Properties

        #region Dependency Property Events

        #region OnParentScaleChanged

        private static void OnParentScaleXPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ZoomElement thisLabel = (ZoomElement)source;

            if (thisLabel.ParentScaleX != 0)
            {
                double tempScale = (1.0 / thisLabel.ParentScaleX) * (thisLabel.Scale);
                thisLabel.SetScaleX(tempScale);
            }
        }

        private static void OnParentScaleYPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            // Put some update logic here...
            ZoomElement thisLabel = (ZoomElement)source;

            if (thisLabel.ParentScaleY != 0)
            {
                double tempScale = (1.0 / thisLabel.ParentScaleY) * (thisLabel.Scale);
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
            ZoomElement thisLabel = (ZoomElement)source;//get this label
            thisLabel.ReinitializePosition(null, null);//update its margins based on the new size
        }

        #endregion OnParentSizeChanged

        #region On X and Y Location Changed

        private static void OnXLocationPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ZoomElement thisLabel = (ZoomElement)source;//get this label
            thisLabel.ReinitializePosition(null, null);//update the label position
        }

        private static void OnYLocationPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ZoomElement thisLabel = (ZoomElement)source;//get this label
            thisLabel.ReinitializePosition(null, null);//update the label position
        }

        #endregion On X and Y Location Changed

        #region On Scale Changed

        private static void OnScaleChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ZoomElement thisLabel = (ZoomElement)source;//get this label
            if (Math.Abs((double)e.NewValue - (double)e.OldValue) < 0.00001) return; 
            if (thisLabel.ParentScaleX != 0)
            {
                double tempScaleX = (1.0 / thisLabel.ParentScaleX) * (thisLabel.Scale);
                thisLabel.SetScaleX(tempScaleX);
            }
            if (thisLabel.ParentScaleY != 0)
            {
                double tempScaleY = (1.0 / thisLabel.ParentScaleY) * (thisLabel.Scale);
                thisLabel.SetScaleY(tempScaleY);
            }
            thisLabel.ReinitializePosition(null, null);//update the label position
        }

        #endregion On Scale Changed

        #endregion Dependency Property Events

        #region Constructor

        /// <summary>
        /// Constructor. Fires before the label is initialized or any of the dependency properties have their values. Sets up the initial layout of the label and prepares the transform group. 
        /// </summary>
        public ZoomElement()
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

            //set the alignment style of the ZoomElement to top and left
            this.VerticalAlignment = VerticalAlignment.Top;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

            //Set an event to fire and position the element after all of the dependency values have been set, but before the label is rendered.
            this.Loaded += SetInitialPositionAndScale;

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
            //sets the position of the ZoomElement to a percentage of the width and height of the parent
            //where Xloc and Yloc are values between 0 and 1 and parentwidth and parentheight are the actual size of the parent element
            if (ParentWidth > 0 && ParentHeight > 0)
            {
                this.Margin = new Thickness((XLoc * ParentWidth) - (this.ActualWidth / 2), (YLoc * ParentHeight) - (this.ActualHeight / 2), 0, 0);
            }
            //Set the initial scale based on the parent's scale
            if (ParentScaleX != 0) SetScaleX((1 / ParentScaleX) * (Scale));
            if (ParentScaleY != 0) SetScaleY((1 / ParentScaleY) * (Scale));

            //Set up the parent sizechanged event
            //this.ParentCanvas.SizeChanged += ReinitializePosition;

            //subscribe to size changed event of the content
            ((FrameworkElement)this.Content).SizeChanged += ContentChangedSize;
        }

        public void ContentChangedSize(object sender, EventArgs e)
        {
            SizeChangedEventArgs args = (SizeChangedEventArgs)e;
            bool needReinitPos = false;
            //we only want to reinitialize the position if the size has changed substantially, not if it has changed because of a machine rounding error
            //if the height has changed
            if (args.HeightChanged)
            {
                //if the height has changed by more than 1/1000 of a pixel
                if (Math.Abs(args.NewSize.Height - args.PreviousSize.Height) > 0.001)
                {
                    //we will reinitialize the position
                    needReinitPos = true;
                }
            }
            //if the width has changed
            if (args.WidthChanged)
            {
                //if the width has changed by more than 1/1000 of a pixel
                if (Math.Abs(args.NewSize.Width - args.PreviousSize.Width) > 0.001)
                {
                    //we will reinitialize the position
                    needReinitPos = true;
                }
            }

            //if we determined that it is needed, we reinitialize the position
            if (needReinitPos) ReinitializePosition(sender, e);
        }

        public void ReinitializePosition(object sender, EventArgs e)
        {
            //Recalculate the correct position of the zoom element using the height and width of the parent container.
            //Also this will position the center of the zoom element on the position. That is why the element size is divided by 2.
            if (ParentWidth > 0 && ParentHeight > 0)
            {
                double newX = (XLoc * ParentWidth) - (this.ActualWidth / 2);
                if ((newX + this.ActualWidth) > ParentWidth) newX = ParentWidth - this.ActualWidth;

                double newY = (YLoc * ParentHeight) - (this.ActualHeight / 2);
                if ((newY + this.ActualHeight) > ParentHeight) newY = ParentHeight - this.ActualHeight;

                this.Margin = new Thickness(newX, newY, 0, 0);
            }
        }
        public void SetScaleX(double xscalar)
        {
            try
            {
                ScaleTransform thisScale = (ScaleTransform)((TransformGroup)this.RenderTransform).Children.First(tr => tr is ScaleTransform);
                if (!thisScale.IsFrozen)
                {
                    if (thisScale.ScaleX != xscalar)
                    { 
                        thisScale.ScaleX = xscalar;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot set XScale on ZoomElement");
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
                    if (thisScale.ScaleY != yscalar)
                    {
                        thisScale.ScaleY = yscalar;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot set YScale on ZoomElement");
                Console.WriteLine(e.StackTrace);
            }
        }

        #endregion Local Methods
    }
}
