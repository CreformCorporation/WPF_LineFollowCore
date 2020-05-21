namespace AGV_Classes
{
    using AGV.Main.AGVClasses;
    using Models;
    using Prism.Mvvm;

    /// <summary>
    /// Defines the <see cref="AGV" />.
    /// </summary>
    public class AGVData : BindableBase
    {
        #region Fields

        /// <summary>
        /// Defines the _AGVBinaries.
        /// </summary>
        private AGVBinaries _AGVBinaries;

        /// <summary>
        /// Defines the _batteryVoltage.
        /// </summary>
        private double _batteryVoltage;

        /// <summary>
        /// Defines the _course.
        /// </summary>
        private ushort _course;

        /// <summary>
        /// Defines the _currentRFIDData.
        /// </summary>
        private RFIDData _currentRFIDData;

        /// <summary>
        /// Defines the _DIO_01.
        /// </summary>
        private ushort _DIO_01;

        /// <summary>
        /// Defines the _DIO_02.
        /// </summary>
        private ushort _DIO_02;

        /// <summary>
        /// Defines the _DIO_03.
        /// </summary>
        private ushort _DIO_03;

        /// <summary>
        /// Defines the _DIO_04.
        /// </summary>
        private ushort _DIO_04;

        /// <summary>
        /// Defines the _DIO_05.
        /// </summary>
        private ushort _DIO_05;

        /// <summary>
        /// Defines the _DIO_06.
        /// </summary>
        private ushort _DIO_06;

        /// <summary>
        /// Defines the _DIO_07.
        /// </summary>
        private ushort _DIO_07;

        /// <summary>
        /// Defines the _faultStatus.
        /// </summary>
        private ushort _faultStatus;

        /// <summary>
        /// Defines the _lastStation.
        /// </summary>
        private ushort _lastStation;

        /// <summary>
        /// Defines the _lastStationTime.
        /// </summary>
        private ushort _lastStationTime;

        /// <summary>
        /// Defines the _nextStation.
        /// </summary>
        private ushort _nextStation;

        /// <summary>
        /// Defines the _partNumber1.
        /// </summary>
        private ushort _partNumber1;

        /// <summary>
        /// Defines the _partNumber2.
        /// </summary>
        private ushort _partNumber2;

        /// <summary>
        /// Defines the _partNumber3.
        /// </summary>
        private ushort _partNumber3;

        /// <summary>
        /// Defines the _partNumber4.
        /// </summary>
        private ushort _partNumber4;

        /// <summary>
        /// Defines the _partNumber5.
        /// </summary>
        private ushort _partNumber5;

        /// <summary>
        /// Defines the _partNumber6.
        /// </summary>
        private ushort _partNumber6;

        /// <summary>
        /// Defines the _screenNumber.
        /// </summary>
        private ushort _screenNumber;

        /// <summary>
        /// Defines the _spare1.
        /// </summary>
        private ushort _spare1;

        /// <summary>
        /// Defines the _spare10.
        /// </summary>
        private ushort _spare10;

        /// <summary>
        /// Defines the _spare2.
        /// </summary>
        private ushort _spare2;

        /// <summary>
        /// Defines the _spare3.
        /// </summary>
        private ushort _spare3;

        /// <summary>
        /// Defines the _spare4.
        /// </summary>
        private ushort _spare4;

        /// <summary>
        /// Defines the _spare5.
        /// </summary>
        private ushort _spare5;

        /// <summary>
        /// Defines the _spare6.
        /// </summary>
        private ushort _spare6;

        /// <summary>
        /// Defines the _spare7.
        /// </summary>
        private ushort _spare7;

        /// <summary>
        /// Defines the _spare8.
        /// </summary>
        private ushort _spare8;

        /// <summary>
        /// Defines the _spare9.
        /// </summary>
        private ushort _spare9;

        /// <summary>
        /// Defines the _speedAGC.
        /// </summary>
        private ushort _speedAGC;

        /// <summary>
        /// Defines the _stationTimer.
        /// </summary>
        private ushort _stationTimer;

        /// <summary>
        /// Defines the _stepAGC.
        /// </summary>
        private ushort _stepAGC;

        /// <summary>
        /// Defines the _viewDirectionA.
        /// </summary>
        private ushort _viewDirectionA;

        /// <summary>
        /// Defines the _viewDirectionB.
        /// </summary>
        private ushort _viewDirectionB;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the AGVBinaries.
        /// </summary>
        public AGVBinaries AGVBinaries
        {
            get { return _AGVBinaries; }
            private set { SetProperty(ref _AGVBinaries, value); }
        }

        /// <summary>
        /// Gets or sets the BatteryVoltage.
        /// </summary>
        public double BatteryVoltage
        {
            get { return _batteryVoltage; }
            set { SetProperty(ref _batteryVoltage, value); }
        }

        /// <summary>
        /// Gets or sets the Course.
        /// </summary>
        public ushort Course
        {
            get { return _course; }
            set { SetProperty(ref _course, value); }
        }

        /// <summary>
        /// Gets or sets the CurrentRFIDData.
        /// </summary>
        public RFIDData CurrentRFIDData
        {
            get { return _currentRFIDData; }
            set { SetProperty(ref _currentRFIDData, value); }
        }

        /// <summary>
        /// Gets or sets the DIO_01.
        /// </summary>
        public ushort DIO_01
        {
            get { return _DIO_01; }
            set
            {
                _DIO_01 = value;
                AGVBinaries.UpdateBinaries_DIO_01(value);
            }
        }

        /// <summary>
        /// Gets or sets the DIO_02.
        /// </summary>
        public ushort DIO_02
        {
            get { return _DIO_02; }
            set
            {
                _DIO_02 = value;
                AGVBinaries.UpdateBinaries_DIO_02(value);
            }
        }

        /// <summary>
        /// Gets or sets the DIO_03.
        /// </summary>
        public ushort DIO_03
        {
            get { return _DIO_03; }
            set { SetProperty(ref _DIO_03, value); }
        }

        /// <summary>
        /// Gets or sets the DIO_04.
        /// </summary>
        public ushort DIO_04
        {
            get { return _DIO_04; }
            set { SetProperty(ref _DIO_04, value); }
        }

        /// <summary>
        /// Gets or sets the DIO_05.
        /// </summary>
        public ushort DIO_05
        {
            get { return _DIO_05; }
            set { SetProperty(ref _DIO_05, value); }
        }

        /// <summary>
        /// Gets or sets the DIO_06.
        /// </summary>
        public ushort DIO_06
        {
            get { return _DIO_06; }
            set { SetProperty(ref _DIO_06, value); }
        }

        /// <summary>
        /// Gets or sets the DIO_07.
        /// </summary>
        public ushort DIO_07
        {
            get { return _DIO_07; }
            set { SetProperty(ref _DIO_07, value); }
        }

        /// <summary>
        /// Gets or sets the FaultStatus.
        /// </summary>
        public ushort FaultStatus
        {
            get { return _faultStatus; }
            set { SetProperty(ref _faultStatus, value); }
        }

        /// <summary>
        /// Gets or sets the lastStation.
        /// </summary>
        public ushort lastStation
        {
            get { return _lastStation; }
            set { SetProperty(ref _lastStation, value); }
        }

        /// <summary>
        /// Gets or sets the lastStationTime.
        /// </summary>
        public ushort lastStationTime
        {
            get { return _lastStationTime; }
            set { SetProperty(ref _lastStationTime, value); }
        }

        /// <summary>
        /// Gets or sets the NextStation.
        /// </summary>
        public ushort NextStation
        {
            get { return _nextStation; }
            set { SetProperty(ref _nextStation, value); }
        }

        /// <summary>
        /// Gets or sets the PartNumber1.
        /// </summary>
        public ushort PartNumber1
        {
            get { return _partNumber1; }
            set { SetProperty(ref _partNumber1, value); }
        }

        /// <summary>
        /// Gets or sets the PartNumber2.
        /// </summary>
        public ushort PartNumber2
        {
            get { return _partNumber2; }
            set { SetProperty(ref _partNumber2, value); }
        }

        /// <summary>
        /// Gets or sets the PartNumber3.
        /// </summary>
        public ushort PartNumber3
        {
            get { return _partNumber3; }
            set { SetProperty(ref _partNumber3, value); }
        }

        /// <summary>
        /// Gets or sets the PartNumber4.
        /// </summary>
        public ushort PartNumber4
        {
            get { return _partNumber4; }
            set { SetProperty(ref _partNumber4, value); }
        }

        /// <summary>
        /// Gets or sets the PartNumber5.
        /// </summary>
        public ushort PartNumber5
        {
            get { return _partNumber5; }
            set { SetProperty(ref _partNumber5, value); }
        }

        /// <summary>
        /// Gets or sets the PartNumber6.
        /// </summary>
        public ushort PartNumber6
        {
            get { return _partNumber6; }
            set { SetProperty(ref _partNumber6, value); }
        }

        /// <summary>
        /// Gets or sets the ScreenNumber.
        /// </summary>
        public ushort ScreenNumber
        {
            get { return _screenNumber; }
            set { SetProperty(ref _screenNumber, value); }
        }

        /// <summary>
        /// Gets or sets the Spare1.
        /// </summary>
        public ushort Spare1
        {
            get { return _spare1; }
            set { SetProperty(ref _spare1, value); }
        }

        /// <summary>
        /// Gets or sets the Spare10.
        /// </summary>
        public ushort Spare10
        {
            get { return _spare10; }
            set { SetProperty(ref _spare10, value); }
        }

        /// <summary>
        /// Gets or sets the Spare2.
        /// </summary>
        public ushort Spare2
        {
            get { return _spare2; }
            set { SetProperty(ref _spare2, value); }
        }

        /// <summary>
        /// Gets or sets the Spare3.
        /// </summary>
        public ushort Spare3
        {
            get { return _spare3; }
            set { SetProperty(ref _spare3, value); }
        }

        /// <summary>
        /// Gets or sets the Spare4.
        /// </summary>
        public ushort Spare4
        {
            get { return _spare4; }
            set { SetProperty(ref _spare4, value); }
        }

        /// <summary>
        /// Gets or sets the Spare5.
        /// </summary>
        public ushort Spare5
        {
            get { return _spare5; }
            set { SetProperty(ref _spare5, value); }
        }

        /// <summary>
        /// Gets or sets the Spare6.
        /// </summary>
        public ushort Spare6
        {
            get { return _spare6; }
            set { SetProperty(ref _spare6, value); }
        }

        /// <summary>
        /// Gets or sets the Spare7.
        /// </summary>
        public ushort Spare7
        {
            get { return _spare7; }
            set { SetProperty(ref _spare7, value); }
        }

        /// <summary>
        /// Gets or sets the Spare8.
        /// </summary>
        public ushort Spare8
        {
            get { return _spare8; }
            set { SetProperty(ref _spare8, value); }
        }

        /// <summary>
        /// Gets or sets the Spare9.
        /// </summary>
        public ushort Spare9
        {
            get { return _spare9; }
            set { SetProperty(ref _spare9, value); }
        }

        /// <summary>
        /// Gets or sets the SpeedAGC.
        /// </summary>
        public ushort SpeedAGC
        {
            get { return _speedAGC; }
            set { SetProperty(ref _speedAGC, value); }
        }

        /// <summary>
        /// Gets or sets the StationTimer.
        /// </summary>
        public ushort StationTimer
        {
            get { return _stationTimer; }
            set { SetProperty(ref _stationTimer, value); }
        }

        /// <summary>
        /// Gets or sets the StepAGC.
        /// </summary>
        public ushort StepAGC
        {
            get { return _stepAGC; }
            set { SetProperty(ref _stepAGC, value); }
        }

        /// <summary>
        /// Gets or sets the ViewDirectionA.
        /// </summary>
        public ushort ViewDirectionA
        {
            get { return _viewDirectionA; }
            set { SetProperty(ref _viewDirectionA, value); }
        }

        /// <summary>
        /// Gets or sets the ViewDirectionB.
        /// </summary>
        public ushort ViewDirectionB
        {
            get { return _viewDirectionB; }
            set { SetProperty(ref _viewDirectionB, value); }
        }

        #endregion
    }
}
