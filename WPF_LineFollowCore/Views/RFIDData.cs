namespace Models
{
    using AGV_Classes;
    using CustomEventArgs;
    using Prism.Mvvm;
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Defines the <see cref="RFIDData" />.
    /// </summary>
    public class RFIDData : BindableBase
    {
        #region Fields

        /// <summary>
        /// A list containing all AGVs currently on this rfid..
        /// </summary>
        private ObservableCollection<AGVData> _agvsOnRFID = new ObservableCollection<AGVData>();

        /// <summary>
        /// Defines the _lastAGVArrivalTime.
        /// </summary>
        private DateTime _lastAGVArrivalTime = new DateTime(1900, 1, 1);

        /// <summary>
        /// Defines the _RFIDNumber.
        /// </summary>
        private int _RFIDNumber;

        /// <summary>
        /// Defines the _xlocation.
        /// </summary>
        private float _xlocation = 0;

        /// <summary>
        /// Defines the _ylocation.
        /// </summary>
        private float _ylocation = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RFIDData"/> class.
        /// </summary>
        /// <param name="rfidNumber">The rfidNumber<see cref="int"/>.</param>
        /// <param name="columnLocation">The columnLocation<see cref="ColumnData"/>.</param>
        /// <param name="xLocation">The xLocation<see cref="float"/>.</param>
        /// <param name="yLocation">The yLocation<see cref="float"/>.</param>
        /// <param name="isException">The isException<see cref="bool"/>.</param>
        /// <param name="isRack">The isRack<see cref="bool"/>.</param>
        public RFIDData(int rfidNumber,  float xLocation = 0, float yLocation = 0)
        {
            _RFIDNumber = rfidNumber;
            _xlocation = xLocation;
            _ylocation = yLocation;
        }

        #endregion

        #region Events

        //Fire this event when an error or exception needs to be logged in a static context.
        /// <summary>
        /// Defines the StaticErrorOccured.
        /// </summary>
        public static event EventHandler StaticErrorOccured;

        //Fire this event when an AGV enters this RFID
        /// <summary>
        /// Defines the AGVEntering.
        /// </summary>
        public event EventHandler AGVEntering;

        //Fire this event when any AGV on this RFID is Leaving this RFID
        /// <summary>
        /// Defines the AGVLeaving.
        /// </summary>
        public event EventHandler AGVLeaving;

        //Fire this event when an AGV starts at this RFID
        /// <summary>
        /// Defines the AGVstarted.
        /// </summary>
        public event EventHandler AGVstarted;

        //Fire this event when a decision is being made
        /// <summary>
        /// Defines the DecisionEvent.
        /// </summary>
        public event EventHandler DecisionEvent;

        //Fire this event when an error or exception needs to be logged.
        /// <summary>
        /// Defines the ErrorOccured.
        /// </summary>
        public event EventHandler ErrorOccured;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the AGVsOnRFID.
        /// </summary>
        public ObservableCollection<AGVData> AGVsOnRFID
        {
            get { return _agvsOnRFID; }
            set { _agvsOnRFID = value; }
        }


        /// <summary>
        /// Gets a value indicating whether ContainsAGV
        /// A boolean indicating that this RFID currently has at least one AGV on it.
        /// Returns true if there is at least one AGV, false otherwise..
        /// </summary>
        public bool ContainsAGV
        {
            get { return _agvsOnRFID.Count > 0; }
        }

        public DateTime LastAGVArrivalTime
        {
            get { return _lastAGVArrivalTime; }
            set
            {
                _lastAGVArrivalTime = value;
                RaisePropertyChanged("LastAGVArrivalTime");
            }
        }


        /// <summary>
        /// Gets a value indicating whether LocationNearOrigin.
        /// </summary>
        public bool LocationNearOrigin
        {
            get
            {
                //if the x or y location of the RFID has been moved away from the origin
                if (Xlocation > 0.0001 || Ylocation > 0.0001)
                {
                    //The RFID has been placed somewhere and is not near the origin
                    return false;
                }
                else//The RFID is still near the origin
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Gets the RFIDNumber.
        /// </summary>
        public int RFIDNumber
        {
            get { return _RFIDNumber; }
        }

        /// <summary>
        /// Gets or sets the Xlocation.
        /// </summary>
        public float Xlocation
        {
            get { return _xlocation; }
            set
            {
                if (_xlocation != value)
                {
                    if (value > 1) _xlocation = 1;
                    else if (value < 0) _xlocation = 0;
                    else _xlocation = value;
                    RaisePropertyChanged("Xlocation");
                    RaisePropertyChanged("LocationNearOrigin");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Ylocation.
        /// </summary>
        public float Ylocation
        {
            get { return _ylocation; }
            set
            {
                if (_ylocation != value)
                {
                    if (value > 1) _ylocation = 1;
                    else if (value < 0) _ylocation = 0;
                    else _ylocation = value;
                    RaisePropertyChanged("Ylocation");
                    RaisePropertyChanged("LocationNearOrigin");
                }
            }
        }

        #endregion

        #region Methods


        /// <summary>
        /// This function is called when a new AGV enters this traffic zone.
        /// </summary>
        /// <param name="agv">.</param>
        public void AGVEnteringRFID(AGVData agv)
        {
            //add the AGV
            AGVsOnRFID.Add(agv);
            //tell the AGV that it is on this RFID
            if (agv.CurrentRFIDData != this) agv.CurrentRFIDData = this;
            //set the last AGV arrival time
            LastAGVArrivalTime = DateTime.Now;

            //Fire the AGVEntering event to alert any subscribers that an AGV has entered this rfid
            AGVEntering?.Invoke(this, new AGVDataEventArgs(agv));
            RaisePropertyChanged("ContainsAGV");
        }

        /// <summary>
        /// The AGVLeavingRFID.
        /// </summary>
        /// <param name="agv">The agv<see cref="AGVData"/>.</param>
        public void AGVLeavingRFID(AGVData agv)
        {
            //remove the AGV because it has left this RFID
            AGVsOnRFID.Remove(agv);
            //Fire the AGVLeaving event to alert any subscribers that an AGV has left this rfid
            AGVLeaving?.Invoke(this, new AGVDataEventArgs(agv));
            RaisePropertyChanged("ContainsAGV");
        }

        /// <summary>
        /// The Clone.
        /// </summary>
        /// <returns>The <see cref="RFIDData"/>.</returns>
        public RFIDData Clone()
        {
            return new RFIDData(_RFIDNumber,  _xlocation, _ylocation);
        }

        //Call this method from subclasses when an error or exception occurs.
        /// <summary>
        /// The FireErrorEvent.
        /// </summary>
        /// <param name="sender">The sender<see cref="RFIDData"/>.</param>
        /// <param name="errorMsg">The errorMsg<see cref="String"/>.</param>
        /// <param name="exceptionMessage">The exceptionMessage<see cref="String"/>.</param>
        /// <param name="stackTrace">The stackTrace<see cref="String"/>.</param>
        protected void FireErrorEvent(RFIDData sender, String errorMsg, String exceptionMessage = null, string stackTrace = null)
        {
            ErrorOccured?.Invoke(sender, new ErrorEventArgs(errorMsg,exceptionMessage,stackTrace));
        }
        #endregion
    }
}
