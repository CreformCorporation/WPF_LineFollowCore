namespace AppSettings
{
    using Prism.Mvvm;
    using System;

    /// <summary>
    /// Defines the <see cref="ScreenPosition" />.
    /// </summary>
    public class ScreenPosition : BindableBase, ICloneable
    {
        #region Fields

        /// <summary>
        /// Defines the _agvImageSize.
        /// </summary>
        private double _agvImageSize = 40.0d;

        /// <summary>
        /// Defines the _agvLabelFontSize.
        /// </summary>
        private double _agvLabelFontSize = 12.0d;

        /// <summary>
        /// Defines the _batteryMonitorHeight.
        /// </summary>
        private double _batteryMonitorHeight = 250.0d;

        /// <summary>
        /// Defines the _batteryMonitorTransformX.
        /// </summary>
        private double _batteryMonitorTransformX = 0.0d;

        /// <summary>
        /// Defines the _batteryMonitorTransformY.
        /// </summary>
        private double _batteryMonitorTransformY = 0.0d;

        /// <summary>
        /// Defines the _batteryMonitorWidth.
        /// </summary>
        private double _batteryMonitorWidth = 250.0d;

        /// <summary>
        /// Defines the _name.
        /// </summary>
        private string _name = "";

        /// <summary>
        /// Defines the _overallScale.
        /// </summary>
        private double _overallScale = 1.0d;

        /// <summary>
        /// Defines the _rfidFontSize.
        /// </summary>
        private double _rfidFontSize = 12.0d;

        /// <summary>
        /// Defines the _scalingTransform.
        /// </summary>
        private double _scalingTransform = 1;

        /// <summary>
        /// Defines the _showAGVs.
        /// </summary>
        private bool _showAGVs = true;

        /// <summary>
        /// Defines the _showBatteryMonitor.
        /// </summary>
        private bool _showBatteryMonitor = true;


        /// <summary>
        /// Defines the _showRFIDs.
        /// </summary>
        private bool _showRFIDs = true;

        /// <summary>
        /// Defines the _translatingTransformX.
        /// </summary>
        private double _translatingTransformX = 0;

        /// <summary>
        /// Defines the _translatingTransformY.
        /// </summary>
        private double _translatingTransformY = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the AGVImageSize.
        /// </summary>
        public double AGVImageSize
        {
            get { return _agvImageSize; }
            set
            {
                SetProperty(ref _agvImageSize, value);

            }
        }

        /// <summary>
        /// Gets or sets the AGVLabelFontSize.
        /// </summary>
        public double AGVLabelFontSize
        {
            get { return _agvLabelFontSize; }
            set
            {

                SetProperty(ref _agvLabelFontSize, value);
            }
        }

        /// <summary>
        /// Gets or sets the BatteryMonitorHeight.
        /// </summary>
        public double BatteryMonitorHeight
        {
            get { return _batteryMonitorHeight; }
            set
            {
                SetProperty(ref _batteryMonitorHeight, value);
            }
        }

        /// <summary>
        /// Gets or sets the BatteryMonitorTransformX.
        /// </summary>
        public double BatteryMonitorTransformX
        {
            get { return _batteryMonitorTransformX; }
            set
            {
                SetProperty(ref _batteryMonitorTransformX, value);
            }
        }

        /// <summary>
        /// Gets or sets the BatteryMonitorTransformY.
        /// </summary>
        public double BatteryMonitorTransformY
        {
            get { return _batteryMonitorTransformY; }
            set
            {
                SetProperty(ref _batteryMonitorTransformY, value);
            }
        }

        /// <summary>
        /// Gets or sets the BatteryMonitorWidth.
        /// </summary>
        public double BatteryMonitorWidth
        {
            get { return _batteryMonitorWidth; }
            set
            {
                SetProperty(ref _batteryMonitorWidth, value);
            }
        }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);

            }
        }

        /// <summary>
        /// Gets or sets the OverallScale.
        /// </summary>
        public double OverallScale
        {
            get { return _overallScale; }
            set
            {
                SetProperty(ref _overallScale, value);
            }
        }

        /// <summary>
        /// Gets or sets the RFIDFontSize.
        /// </summary>
        public double RFIDFontSize
        {
            get { return _rfidFontSize; }
            set
            {
                SetProperty(ref _rfidFontSize, value);
            }
        }

        /// <summary>
        /// Gets or sets the ScalingTransform.
        /// </summary>
        public double ScalingTransform
        {
            get { return _scalingTransform; }
            set
            {
                SetProperty(ref _scalingTransform, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowAGVs.
        /// </summary>
        public bool ShowAGVs
        {
            get { return _showAGVs; }
            set
            {
                SetProperty(ref _showAGVs, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowBatteryMonitor.
        /// </summary>
        public bool ShowBatteryMonitor
        {
            get { return _showBatteryMonitor; }
            set
            {
                if (_showBatteryMonitor != value)
                {
                    //reset the battery monitor position
                    this.BatteryMonitorTransformX = 0.0;
                    this.BatteryMonitorTransformY = 0.0;
                    this.BatteryMonitorWidth = 250.0;
                    this.BatteryMonitorHeight = 250.0;
                    RaisePropertyChanged("ShowBatteryMonitor");
                }
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether ShowRFIDs.
        /// </summary>
        public bool ShowRFIDs
        {
            get { return _showRFIDs; }
            set
            {
                SetProperty(ref _showRFIDs, value);

            }
        }


        /// <summary>
        /// Gets or sets the TranslatingTransformX.
        /// </summary>
        public double TranslatingTransformX
        {
            get { return _translatingTransformX; }
            set
            {
                SetProperty(ref _translatingTransformX, value);
            }
        }

        /// <summary>
        /// Gets or sets the TranslatingTransformY.
        /// </summary>
        public double TranslatingTransformY
        {
            get { return _translatingTransformY; }
            set
            {
                SetProperty(ref _translatingTransformY, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The Clone.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object Clone()
        {
            return new ScreenPosition()
            {
                Name = this.Name,
                ScalingTransform = this.ScalingTransform,
                TranslatingTransformX = this.TranslatingTransformX,
                TranslatingTransformY = this.TranslatingTransformY,
                BatteryMonitorTransformX = this.BatteryMonitorTransformX,
                BatteryMonitorTransformY = this.BatteryMonitorTransformY,
                BatteryMonitorWidth = this.BatteryMonitorWidth,
                BatteryMonitorHeight = this.BatteryMonitorHeight,
                OverallScale = this.OverallScale,
                RFIDFontSize = this.RFIDFontSize,
                AGVImageSize = this.AGVImageSize,
                AGVLabelFontSize = this.AGVLabelFontSize,
                ShowAGVs = this.ShowAGVs,
                ShowRFIDs = this.ShowRFIDs,
                ShowBatteryMonitor = this.ShowBatteryMonitor,
            };
        }

        /// <summary>
        /// The MemberwiseReplace.
        /// </summary>
        /// <param name="screenNeedingReplaced">The screenNeedingReplaced<see cref="ScreenPosition"/>.</param>
        public void MemberwiseReplace(ScreenPosition screenNeedingReplaced)
        {
            screenNeedingReplaced.Name = this.Name;
            screenNeedingReplaced.ScalingTransform = this.ScalingTransform;
            screenNeedingReplaced.TranslatingTransformX = this.TranslatingTransformX;
            screenNeedingReplaced.TranslatingTransformY = this.TranslatingTransformY;
            screenNeedingReplaced.BatteryMonitorTransformX = this.BatteryMonitorTransformX;
            screenNeedingReplaced.BatteryMonitorTransformY = this.BatteryMonitorTransformY;
            screenNeedingReplaced.BatteryMonitorWidth = this.BatteryMonitorWidth;
            screenNeedingReplaced.BatteryMonitorHeight = this.BatteryMonitorHeight;
            screenNeedingReplaced.OverallScale = this.OverallScale;
            screenNeedingReplaced.RFIDFontSize = this.RFIDFontSize;
            screenNeedingReplaced.AGVImageSize = this.AGVImageSize;
            screenNeedingReplaced.AGVLabelFontSize = this.AGVLabelFontSize;
            screenNeedingReplaced.ShowAGVs = this.ShowAGVs;
            screenNeedingReplaced.ShowRFIDs = this.ShowRFIDs;
            screenNeedingReplaced.ShowBatteryMonitor = this.ShowBatteryMonitor;
        }

        #endregion
    }
}
