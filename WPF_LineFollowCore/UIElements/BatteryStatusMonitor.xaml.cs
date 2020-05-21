namespace UIElements
{
    using AGV_Classes;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for BatteryStatusMonitor.xaml.
    /// </summary>
    public partial class BatteryStatusMonitor : UserControl
    {
        #region Fields

        // Using a DependencyProperty as the backing store for GridItemSourceProperty.  This enables animation, styling, binding, etc...
        /// <summary>
        /// Defines the BatteryGridItemSourceProperty.
        /// </summary>
        public static readonly DependencyProperty BatteryGridItemSourceProperty =
            DependencyProperty.Register("BatteryGridItemSource", typeof(ObservableCollection<AGVData>), typeof(BatteryStatusMonitor), new PropertyMetadata(default(ObservableCollection<AGVData>), BatteryItemSourceChanged));

        // Using a DependencyProperty as the backing store for CanRepositionProperty.  This enables animation, styling, binding, etc...
        /// <summary>
        /// Defines the CanRepositionProperty.
        /// </summary>
        public static readonly DependencyProperty CanRepositionProperty =
            DependencyProperty.Register("CanReposition", typeof(bool), typeof(BatteryStatusMonitor), new PropertyMetadata(default(bool)));

        /// <summary>
        /// Defines the GridViewHeightProperty.
        /// </summary>
        public static readonly DependencyProperty GridViewHeightProperty =
            DependencyProperty.Register("GridViewHeight", typeof(double), typeof(BatteryStatusMonitor), new PropertyMetadata(250.0, GridViewHeightChanged));

        /// <summary>
        /// Defines the GridViewWidthProperty.
        /// </summary>
        public static readonly DependencyProperty GridViewWidthProperty =
            DependencyProperty.Register("GridViewWidth", typeof(double), typeof(BatteryStatusMonitor), new PropertyMetadata(250.0, GridViewWidthChanged));

        /// <summary>
        /// Defines the XTranslationProperty.
        /// </summary>
        public static readonly DependencyProperty XTranslationProperty =
            DependencyProperty.Register("XTranslation", typeof(double), typeof(BatteryStatusMonitor), new PropertyMetadata(0.0, XtranslationChanged));

        /// <summary>
        /// Defines the YTranslationProperty.
        /// </summary>
        public static readonly DependencyProperty YTranslationProperty =
            DependencyProperty.Register("YTranslation", typeof(double), typeof(BatteryStatusMonitor), new PropertyMetadata(0.0, YtranslationChanged));

        /// <summary>
        /// Defines the xTranslation, yTranslation.
        /// </summary>
        internal double xTranslation, yTranslation;

        /// <summary>
        /// Defines the _batteryGridWidth.
        /// </summary>
        private double _batteryGridWidth = 250;

        /// <summary>
        /// Defines the _columnCount.
        /// </summary>
        private int _columnCount = 1;

        /// <summary>
        /// Defines the _gridViews.
        /// </summary>
        private ObservableCollection<ICollectionView> _gridViews = new ObservableCollection<ICollectionView>();

        /// <summary>
        /// Defines the origin.
        /// </summary>
        private Point origin;//used to translate the element from it's original position

        /// <summary>
        /// Defines the OriginalWidthandHeight.
        /// </summary>
        private Point OriginalWidthandHeight;

        /// <summary>
        /// Defines the start.
        /// </summary>
        private Point start;//stores the position in the window that the mouse is clicked

        /// <summary>
        /// Defines the tt.
        /// </summary>
        private TranslateTransform tt = new TranslateTransform();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BatteryStatusMonitor"/> class.
        /// </summary>
        public BatteryStatusMonitor()
        {
            InitializeComponent();
            DataContext = this;

            //Set up translation
            TransformGroup group = new TransformGroup();
            group.Children.Add(tt);
            this.RenderTransform = group;
            this.RenderTransformOrigin = new Point(0.0, 0.0);

            GridViewStackPanel.MouseLeftButtonDown += GridContainer_MouseLeftButtonDown;
            GridViewStackPanel.MouseLeftButtonUp += GridContainer_MouseLeftButtonUp;
            GridViewStackPanel.MouseMove += GridContainer_MouseMove;

            this.Loaded += BatteryStatusMonitor_Loaded;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the BatteryGridItemSource.
        /// </summary>
        public ObservableCollection<AGVData> BatteryGridItemSource
        {
            get { return (ObservableCollection<AGVData>)GetValue(BatteryGridItemSourceProperty); }
            set { SetValue(BatteryGridItemSourceProperty, value); }
        }

        /// <summary>
        /// Gets the BatteryGridWidth.
        /// </summary>
        public double BatteryGridWidth
        {
            get { return _batteryGridWidth; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether CanReposition.
        /// </summary>
        public bool CanReposition
        {
            get { return (bool)GetValue(CanRepositionProperty); }
            set { SetValue(CanRepositionProperty, value); }
        }

        //Y Translation
        /// <summary>
        /// Gets or sets the GridViewHeight.
        /// </summary>
        public double GridViewHeight
        {
            get { return (double)GetValue(GridViewHeightProperty); }
            set
            {
                SetValue(GridViewHeightProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the GridViews.
        /// </summary>
        public ObservableCollection<ICollectionView> GridViews
        {
            get { return _gridViews; }
            set
            {
                if (_gridViews != value)
                {
                    _gridViews = value;
                }
            }
        }

        //X Translation
        /// <summary>
        /// Gets or sets the GridViewWidth.
        /// </summary>
        public double GridViewWidth
        {
            get { return (double)GetValue(GridViewWidthProperty); }
            set
            {
                SetValue(GridViewWidthProperty, value);
            }
        }

        //X Translation
        /// <summary>
        /// Gets or sets the XTranslation.
        /// </summary>
        public double XTranslation
        {
            get { return (double)GetValue(XTranslationProperty); }
            set
            {
                SetValue(XTranslationProperty, value);
            }
        }

        //Y Translation
        /// <summary>
        /// Gets or sets the YTranslation.
        /// </summary>
        public double YTranslation
        {
            get { return (double)GetValue(YTranslationProperty); }
            set
            {
                SetValue(YTranslationProperty, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The BatteryStatusMonitor_Loaded.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        internal void BatteryStatusMonitor_Loaded(object sender, RoutedEventArgs e)
        {
            //set initial translation properties
            tt.X = XTranslation;
            tt.Y = YTranslation;
        }

        /// <summary>
        /// The Footer_MouseEnter.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseEventArgs"/>.</param>
        internal void Footer_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CanReposition)
            {
                //change the cursor to indicate scaling
                this.Cursor = Cursors.SizeNWSE;
            }
        }

        /// <summary>
        /// The Footer_MouseLeave.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseEventArgs"/>.</param>
        internal void Footer_MouseLeave(object sender, MouseEventArgs e)
        {
            //restore the cursor
            this.Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// The Footer_MouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
        internal void Footer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (CanReposition)
            {
                //get the mouse's current position inside of the Window
                start = e.GetPosition(Application.Current.MainWindow);
                //get the current size of the element
                OriginalWidthandHeight.X = this.GridContainer.ActualWidth;
                OriginalWidthandHeight.Y = this.GridContainer.ActualHeight;
                //capture the mouse on the element to indicate that it is in use
                Footer.CaptureMouse();
            }
        }

        /// <summary>
        /// The Footer_MouseLeftButtonUp.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
        internal void Footer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Footer.ReleaseMouseCapture();
        }

        /// <summary>
        /// The Footer_MouseMove.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseEventArgs"/>.</param>
        internal void Footer_MouseMove(object sender, MouseEventArgs e)
        {
            if (Footer.IsMouseCaptured)
            {
                //calculate the distance that the mouse has been moved since the mouse button was pressed
                Vector v = start - e.GetPosition(Application.Current.MainWindow);
                //resize the element according to the distance the mouse moved
                double newWidth = OriginalWidthandHeight.X - v.X;
                //prevent the width from being to set to less than the minimum width
                if (newWidth < this.GridContainer.MinWidth) newWidth = this.GridContainer.MinWidth;
                double newHeight = OriginalWidthandHeight.Y - v.Y;
                //prevent the Height from being to set to less than the minimum Height
                if (newHeight < this.GridContainer.MinHeight) newHeight = this.GridContainer.MinHeight;
                //apply the new size
                this.GridContainer.Width = newWidth;
                this.GridViewWidth = newWidth;
                this.GridContainer.Height = newHeight;
                this.GridViewHeight = newHeight;
            }
        }

        /// <summary>
        /// The GridContainer_MouseLeftButtonDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
        internal void GridContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (CanReposition)
            {
                //get the mouse's current position inside of the Window
                start = e.GetPosition(Application.Current.MainWindow);
                //get the current position of the element
                origin = new Point(tt.X, tt.Y);
                //capture the mouse on the element to indicate that it is in use
                GridViewStackPanel.CaptureMouse();
            }
        }

        /// <summary>
        /// The GridContainer_MouseLeftButtonUp.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseButtonEventArgs"/>.</param>
        internal void GridContainer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GridViewStackPanel.ReleaseMouseCapture();
        }

        /// <summary>
        /// The GridContainer_MouseMove.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseEventArgs"/>.</param>
        internal void GridContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (GridViewStackPanel.IsMouseCaptured)
            {
                //calculate the distance that the mouse has been moved since the mouse button was pressed
                Vector v = start - e.GetPosition(Application.Current.MainWindow);
                //translate the element from where it was when the mouse was clicked the same direction and distance that the mouse has moved
                //X Translation
                xTranslation = origin.X - v.X;
                //prevent negative X translation
                if (xTranslation < 0) xTranslation = 0;
                else if (xTranslation > (Application.Current.MainWindow.RenderSize.Width - this.ActualWidth)) xTranslation = (Application.Current.MainWindow.RenderSize.Width - this.ActualWidth);
                tt.X = xTranslation;
                XTranslation = tt.X;

                //Y Translation
                yTranslation = origin.Y - v.Y;
                //prevent negative Y translation
                if (yTranslation < 0) yTranslation = 0;
                else if (yTranslation > (Application.Current.MainWindow.RenderSize.Height - this.ActualHeight)) yTranslation = (Application.Current.MainWindow.RenderSize.Height - this.ActualHeight);
                tt.Y = yTranslation;
                YTranslation = tt.Y;

            }
        }

        /// <summary>
        /// The BatteryItemSourceChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="DependencyObject"/>.</param>
        /// <param name="e">The e<see cref="DependencyPropertyChangedEventArgs"/>.</param>
        private static void BatteryItemSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            BatteryStatusMonitor bsm = (BatteryStatusMonitor)sender;
            bsm.SetUpBatteryColumns();
            bsm.GenerateGrids(bsm._columnCount);
        }

        /// <summary>
        /// The GridViewHeightChanged.
        /// </summary>
        /// <param name="source">The source<see cref="DependencyObject"/>.</param>
        /// <param name="e">The e<see cref="DependencyPropertyChangedEventArgs"/>.</param>
        private static void GridViewHeightChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            BatteryStatusMonitor thisMonitor = (BatteryStatusMonitor)source;
            thisMonitor.GridContainer.Height = (double)e.NewValue;
        }

        /// <summary>
        /// The GridViewWidthChanged.
        /// </summary>
        /// <param name="source">The source<see cref="DependencyObject"/>.</param>
        /// <param name="e">The e<see cref="DependencyPropertyChangedEventArgs"/>.</param>
        private static void GridViewWidthChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            BatteryStatusMonitor thisMonitor = (BatteryStatusMonitor)source;
            thisMonitor.GridContainer.Width = (double)e.NewValue;
        }

        /// <summary>
        /// The XtranslationChanged.
        /// </summary>
        /// <param name="source">The source<see cref="DependencyObject"/>.</param>
        /// <param name="e">The e<see cref="DependencyPropertyChangedEventArgs"/>.</param>
        private static void XtranslationChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            BatteryStatusMonitor thisMonitor = (BatteryStatusMonitor)source;
            thisMonitor.tt.X = (double)e.NewValue;
        }

        /// <summary>
        /// The YtranslationChanged.
        /// </summary>
        /// <param name="source">The source<see cref="DependencyObject"/>.</param>
        /// <param name="e">The e<see cref="DependencyPropertyChangedEventArgs"/>.</param>
        private static void YtranslationChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            BatteryStatusMonitor thisMonitor = (BatteryStatusMonitor)source;
            thisMonitor.tt.Y = (double)e.NewValue;
        }

        /// <summary>
        /// This function re-calculates the gridview columns to prevent any issues with the columns not being the proper size.
        /// </summary>
        /// <param name="sender">.</param>
        /// <param name="e">.</param>
        private void BatteryListView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                ListView lv = sender as ListView;
                if (lv.IsVisible)
                {
                    GridView gv = (GridView)lv.View;
                    foreach (GridViewColumn gvc in gv.Columns.ToList())
                    {
                        gvc.Width = 0; //set columnwidth to zero
                        gvc.Width = double.NaN; //re-initialize the width
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while changing battery monitor visibility.");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// The ColumnFilter.
        /// </summary>
        /// <param name="columnNum">The columnNum<see cref="int"/>.</param>
        /// <param name="minIndex">The minIndex<see cref="int"/>.</param>
        /// <param name="numOfItemsInThisCol">The numOfItemsInThisCol<see cref="int"/>.</param>
        /// <param name="agv">The agv<see cref="AGVData"/>.</param>
        /// <param name="source">The source<see cref="ObservableCollection{AGVData}"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool ColumnFilter(int columnNum, int minIndex, int numOfItemsInThisCol, AGVData agv, ObservableCollection<AGVData> source)
        {
            int maxIndex = (minIndex + numOfItemsInThisCol) - 1;
            int currIndex = source.IndexOf(agv);

            return (currIndex >= minIndex && currIndex <= maxIndex);
        }

        /// <summary>
        /// The FalseFilter.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool FalseFilter(object obj)
        {
            AGVData tmpAGV = (AGVData)obj;
            return false;
        }

        /// <summary>
        /// The GenerateGrids.
        /// </summary>
        /// <param name="ColumnCount">The ColumnCount<see cref="int"/>.</param>
        private void GenerateGrids(int ColumnCount)
        {
            if (_batteryGridWidth < 1 || BatteryGridItemSource == null) return;

            int colCounter = 1;
            int totalItems = BatteryGridItemSource.Count;
            int itemsLeft = BatteryGridItemSource.Count;
            int columnsLeft = _columnCount;
            foreach (ICollectionView col in GridViews)
            {
                int numOfItemsForThisCol = 0;
                int minIndexForThisCol = 0;
                //decide how many items go into this column
                if (columnsLeft > 0)
                {
                    //get the starting index for this column
                    minIndexForThisCol = totalItems - itemsLeft;
                    //calculate how many items belong in this column
                    numOfItemsForThisCol = (int)Math.Ceiling(((decimal)itemsLeft) / ((decimal)columnsLeft));
                }
                else
                {
                    numOfItemsForThisCol = 0;
                }
                itemsLeft = itemsLeft - numOfItemsForThisCol;
                columnsLeft--;

                col.Filter = new Predicate<object>(agv => { return ColumnFilter(colCounter, minIndexForThisCol, numOfItemsForThisCol, (AGVData)agv, BatteryGridItemSource); });
                col.Refresh();
                colCounter++;
            }
        }

        /// <summary>
        /// The GridContainer_SizeChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="SizeChangedEventArgs"/>.</param>
        private void GridContainer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int oldColumnCount = _columnCount;
            //calculate new column count
            if (_batteryGridWidth < 1 || BatteryGridItemSource == null) return;
            _columnCount = (int)Math.Floor(Footer.ActualWidth / _batteryGridWidth);
            if (_columnCount <= 0) _columnCount = 1;

            //if the column count changed
            if (oldColumnCount != _columnCount)
            {
                //regenerate the grids
                GenerateGrids(_columnCount);
            }
        }

        /// <summary>
        /// The SetUpBatteryColumns.
        /// </summary>
        private void SetUpBatteryColumns()
        {
            //create 10 ICollectionViews for the columns
            //at first, put all elements in the first column
            for (int i = 0; i < 10; i++)
            {
                ICollectionView tmpView = new AutoUpdatingCollectionView(BatteryGridItemSource);
                if (i == 0) tmpView.Filter = TrueFilter;
                else tmpView.Filter = FalseFilter;
                tmpView.Refresh();
                GridViews.Add(tmpView);
            }
        }

        /// <summary>
        /// The TrueFilter.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool TrueFilter(object obj)
        {
            AGVData tmpAGV = (AGVData)obj;
            return true;
        }

        #endregion
    }
}
