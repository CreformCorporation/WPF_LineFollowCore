namespace AGCs
{
    using System;

    /// <summary>
    /// Defines the <see cref="AGC_TC_Data" />.
    /// </summary>
    public abstract class AGC_TC_Data
    {
        #region Fields

        //Course (40010)
        /// <summary>
        /// Defines the course.
        /// </summary>
        private int course;

        //Current Screen Number (40019)
        /// <summary>
        /// Defines the currentScreenNumber.
        /// </summary>
        private int currentScreenNumber;

        //Fault Status (40012)
        /// <summary>
        /// Defines the faultStatus.
        /// </summary>
        private int faultStatus;

        //to TC
        //Last Station (40008)
        /// <summary>
        /// Defines the lastStation.
        /// </summary>
        private int lastStation;

        //Next Station (40009)
        /// <summary>
        /// Defines the nextStation.
        /// </summary>
        private int nextStation;

        // Course to AGC
        /// <summary>
        /// Defines the setCourse.
        /// </summary>
        private int setCourse;

        //from TC
        // Speed
        /// <summary>
        /// Defines the setSpeed.
        /// </summary>
        private int setSpeed;

        // View A
        /// <summary>
        /// Defines the setViewA.
        /// </summary>
        private int setViewA;

        // View B
        /// <summary>
        /// Defines the setViewB.
        /// </summary>
        private int setViewB;

        //Speed (40014)
        /// <summary>
        /// Defines the speed.
        /// </summary>
        private int speed;

        //Station Time Last (40018)
        /// <summary>
        /// Defines the stationTimeLast.
        /// </summary>
        private int stationTimeLast;

        //Station Timer (40017)
        /// <summary>
        /// Defines the stationTimer.
        /// </summary>
        private int stationTimer;

        //Step (40011)
        /// <summary>
        /// Defines the step.
        /// </summary>
        private int step;

        //View A Direction (40015)
        /// <summary>
        /// Defines the view_A_Direction.
        /// </summary>
        private int view_A_Direction;

        //View B Direction (40016)
        /// <summary>
        /// Defines the view_B_Direction.
        /// </summary>
        private int view_B_Direction;

        //Voltage (40013)
        /// <summary>
        /// Defines the voltage.
        /// </summary>
        private int voltage;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AGC_TC_Data"/> class.
        /// </summary>
        public AGC_TC_Data()
        {
        }

        #endregion

        #region Enums

        //to TC Bits 
        //       (40001)
        // 1.0   Temp Slow 
        // 1.1   Temp Stop
        // 1.2   Tow Pin Up
        // 1.3   Tow Pin Down
        // 1.4   Following Right
        // 1.5   Following Left
        // 1.6   On Path / Tape
        // 1.7   Present
        // 1.8   Fault
        // 1.9   Stop Override Status
        // 1.10  Master On
        // 1.11  Charge Status
        // 1.12  Spare
        // 1.13  Auto Run
        // 1.14  Auto Direction
        // 1.15  Override TC
        [Flags]
        public enum AGCStatusFlagsDO_01
        {
            /// <summary>
            /// Defines the None.
            /// </summary>
            None = 0,                       // 0000 0000  0000 0000

            /// <summary>
            /// Defines the Temp_Slow.
            /// </summary>
            Temp_Slow = 1 << 0,     // 0000 0000  0000 0001

            /// <summary>
            /// Defines the Temp_Stop.
            /// </summary>
            Temp_Stop = 1 << 1,            // 0000 0000  0000 0010

            /// <summary>
            /// Defines the Tow_Pin_Up.
            /// </summary>
            Tow_Pin_Up = 1 << 2,        // 0000 0000  0000 0100

            /// <summary>
            /// Defines the Tow_Pin_Down.
            /// </summary>
            Tow_Pin_Down = 1 << 3,           // 0000 0000  0000 1000

            /// <summary>
            /// Defines the Following_Right.
            /// </summary>
            Following_Right = 1 << 4,     // 0000 0000  0001 0000

            /// <summary>
            /// Defines the Following_Left.
            /// </summary>
            Following_Left = 1 << 5,          // 0000 0000  0010 0000

            /// <summary>
            /// Defines the On_Path.
            /// </summary>
            On_Path = 1 << 6,         // 0000 0000  0100 0000

            /// <summary>
            /// Defines the Present.
            /// </summary>
            Present = 1 << 7,      // 0000 0000  1000 0000

            /// <summary>
            /// Defines the Faulted.
            /// </summary>
            Faulted = 1 << 8,     // 0000 0001  0000 0000

            /// <summary>
            /// Defines the Stop_Override_Status.
            /// </summary>
            Stop_Override_Status = 1 << 9,          // 0000 0010  0000 0000

            /// <summary>
            /// Defines the Master_On.
            /// </summary>
            Master_On = 1 << 10,        // 0000 0100  0000 0000

            /// <summary>
            /// Defines the AGCStatusDO_01_11.
            /// </summary>
            AGCStatusDO_01_11 = 1 << 11,     // 0000 1000  0000 0000

            /// <summary>
            /// Defines the Charge_Status.
            /// </summary>
            Charge_Status = 1 << 12,   // 0001 0000  0000 0000

            /// <summary>
            /// Defines the Auto_Run.
            /// </summary>
            Auto_Run = 1 << 13,   // 0010 0000  0000 0000

            /// <summary>
            /// Defines the Auto_Direction.
            /// </summary>
            Auto_Direction = 1 << 14,   // 0100 0000  0000 0000

            /// <summary>
            /// Defines the Override_TC.
            /// </summary>
            Override_TC = 1 << 15,   // 1000 0000  0000 0000

        }

        //       (40002)
        // 2.0   Zone Clear
        // 2.1   Zone Clear
        // 2.2   Auto Mode
        // 2.3   Control Off
        // 2.4   Start PB
        // 2.5   Stop PB
        // 2.6   Reset PB
        // 2.7   Start PB Alarm
        // 2.8   TC Signal On
        // 2.9   Pulse Signal
        // 2.10  AGV Enable
        [Flags]
        public enum AGCStatusFlagsDO_02
        {
            /// <summary>
            /// Defines the None.
            /// </summary>
            None = 0,                      // 0000 0000  0000 0000

            /// <summary>
            /// Defines the Zone_Clear0.
            /// </summary>
            Zone_Clear0 = 1 << 0,          // 0000 0000  0000 0001

            /// <summary>
            /// Defines the Zone_Clear1.
            /// </summary>
            Zone_Clear1 = 1 << 1,          // 0000 0000  0000 0010

            /// <summary>
            /// Defines the Auto_Mode.
            /// </summary>
            Auto_Mode = 1 << 2,            // 0000 0000  0000 0100

            /// <summary>
            /// Defines the Control_Off.
            /// </summary>
            Control_Off = 1 << 3,          // 0000 0000  0000 1000

            /// <summary>
            /// Defines the Start_PB.
            /// </summary>
            Start_PB = 1 << 4,             // 0000 0000  0001 0000

            /// <summary>
            /// Defines the Stop_PB.
            /// </summary>
            Stop_PB = 1 << 5,              // 0000 0000  0010 0000

            /// <summary>
            /// Defines the Reset_PB.
            /// </summary>
            Reset_PB = 1 << 6,             // 0000 0000  0100 0000

            /// <summary>
            /// Defines the Start_PB_Alarm.
            /// </summary>
            Start_PB_Alarm = 1 << 7,       // 0000 0000  1000 0000

            /// <summary>
            /// Defines the TC_Signal_On.
            /// </summary>
            TC_Signal_On = 1 << 8,         // 0000 0001  0000 0000

            /// <summary>
            /// Defines the Pulse_Signal.
            /// </summary>
            Pulse_Signal = 1 << 9,         // 0000 0010  0000 0000

            /// <summary>
            /// Defines the AGV_Enable.
            /// </summary>
            AGV_Enable = 1 << 10,          // 0000 0100  0000 0000

            /// <summary>
            /// Defines the AGCStatusDO_02_11.
            /// </summary>
            AGCStatusDO_02_11 = 1 << 11,   // 0000 1000  0000 0000

            /// <summary>
            /// Defines the AGCStatusDO_02_12.
            /// </summary>
            AGCStatusDO_02_12 = 1 << 12,   // 0001 0000  0000 0000

            /// <summary>
            /// Defines the AGCStatusDO_02_13.
            /// </summary>
            AGCStatusDO_02_13 = 1 << 13,   // 0010 0000  0000 0000

            /// <summary>
            /// Defines the AGCStatusDO_02_14.
            /// </summary>
            AGCStatusDO_02_14 = 1 << 14,   // 0100 0000  0000 0000

            /// <summary>
            /// Defines the AGCStatusDO_02_15.
            /// </summary>
            AGCStatusDO_02_15 = 1 << 15,   // 1000 0000  0000 0000
        }

        //from TC Bits 
        //       (40301)
        // 1.0   Stop Override
        // 1.1   Remote Start
        // 1.2   Remote Stop
        // 1.3   Power Down
        // 1.4   Heart Beat
        // 1.5   Turn Left
        // 1.6   Turn Right
        // 1.7   Direction
        // 1.8   Autofind
        // 1.9   Temp Slow
        // 1.10  Master On
        // 1.11  Traffic Control Enable
        [Flags]
        public enum AGC_ControlFlagsDI_01
        {
            /// <summary>
            /// Defines the None.
            /// </summary>
            None = 0,                            // 0000 0000  0000 0000	

            /// <summary>
            /// Defines the Stop_Override.
            /// </summary>
            Stop_Override = 1 << 0,              // 0000 0000  0000 0001

            /// <summary>
            /// Defines the Remote_Start.
            /// </summary>
            Remote_Start = 1 << 1,               // 0000 0000  0000 0010

            /// <summary>
            /// Defines the Remote_Stop.
            /// </summary>
            Remote_Stop = 1 << 2,                // 0000 0000  0000 0100

            /// <summary>
            /// Defines the Power_Down.
            /// </summary>
            Power_Down = 1 << 3,                 // 0000 0000  0000 1000

            /// <summary>
            /// Defines the Heart_Beat.
            /// </summary>
            Heart_Beat = 1 << 4,                 // 0000 0000  0001 0000

            /// <summary>
            /// Defines the Turn_Left.
            /// </summary>
            Turn_Left = 1 << 5,                  // 0000 0000  0010 0000

            /// <summary>
            /// Defines the Turn_Right.
            /// </summary>
            Turn_Right = 1 << 6,                 // 0000 0000  0100 0000

            /// <summary>
            /// Defines the Direction.
            /// </summary>
            Direction = 1 << 7,                  // 0000 0000  1000 0000

            /// <summary>
            /// Defines the Autofind.
            /// </summary>
            Autofind = 1 << 8,                   // 0000 0001  0000 0000

            /// <summary>
            /// Defines the Temp_Slow.
            /// </summary>
            Temp_Slow = 1 << 9,                  // 0000 0010  0000 0000

            /// <summary>
            /// Defines the Master_On.
            /// </summary>
            Master_On = 1 << 10,                 // 0000 0100  0000 0000

            /// <summary>
            /// Defines the Traffic_Control_Enable.
            /// </summary>
            Traffic_Control_Enable = 1 << 11,    // 0000 1000  0000 0000

            /// <summary>
            /// Defines the AGCControlDI_01_12.
            /// </summary>
            AGCControlDI_01_12 = 1 << 12,         // 0001 0000  0000 0000

            /// <summary>
            /// Defines the AGCControlDI_01_13.
            /// </summary>
            AGCControlDI_01_13 = 1 << 13,         // 0010 0000  0000 0000

            /// <summary>
            /// Defines the AGCControlDI_01_14.
            /// </summary>
            AGCControlDI_01_14 = 1 << 14,         // 0100 0000  0000 0000

            /// <summary>
            /// Defines the AGCControlDI_01_15.
            /// </summary>
            AGCControlDI_01_15 = 1 << 15,	     // 1000 0000  0000 0000



        }

        //       (40302)
        // 2.0   Charge Command
        // 2.1   Exception Command
        // 2.2   TC Overide Stop
        // 2.3   TC Enabled/ Offline
        // 2.4   TC Stop
        [Flags]
        public enum AGC_ControlFlags_DI_02
        {
            /// <summary>
            /// Defines the None.
            /// </summary>
            None = 0,                             // 0000 0000  0000 0000

            /// <summary>
            /// Defines the Charge_Command.
            /// </summary>
            Charge_Command = 1 << 0,              // 0000 0000  0000 0001

            /// <summary>
            /// Defines the Exception_Command.
            /// </summary>
            Exception_Command = 1 << 1,           // 0000 0000  0000 0010

            /// <summary>
            /// Defines the TC_Overide_Stop.
            /// </summary>
            TC_Overide_Stop = 1 << 2,             // 0000 0000  0000 0100

            /// <summary>
            /// Defines the TC_Enabled.
            /// </summary>
            TC_Enabled = 1 << 3,                  // 0000 0000  0000 1000

            /// <summary>
            /// Defines the TC_Stop.
            /// </summary>
            TC_Stop = 1 << 4,                     // 0000 0000  0001 0000

            /// <summary>
            /// Defines the AGCControlFlags_DI_02_05.
            /// </summary>
            AGCControlFlags_DI_02_05 = 1 << 5,    // 0000 0000  0010 0000

            /// <summary>
            /// Defines the AGCControlFlags_DI_02_06.
            /// </summary>
            AGCControlFlags_DI_02_06 = 1 << 6,    // 0000 0000  0100 0000

            /// <summary>
            /// Defines the AGCControlFlags_DI_02_07.
            /// </summary>
            AGCControlFlags_DI_02_07 = 1 << 7,    // 0000 0000  1000 0000

            /// <summary>
            /// Defines the AGCControlFlags_DI_02_08.
            /// </summary>
            AGCControlFlags_DI_02_08 = 1 << 8,    // 0000 0001  0000 0000

            /// <summary>
            /// Defines the AGCControlFlags_DI_02_09.
            /// </summary>
            AGCControlFlags_DI_02_09 = 1 << 9,    // 0000 0010  0000 0000

            /// <summary>
            /// Defines the AGCControlFlags_DI_02_10.
            /// </summary>
            AGCControlFlags_DI_02_10 = 1 << 10,   // 0000 0100  0000 0000

            /// <summary>
            /// Defines the AGCControlFlags_DI_02_11.
            /// </summary>
            AGCControlFlags_DI_02_11 = 1 << 11,   // 0000 1000  0000 0000

            /// <summary>
            /// Defines the AGCControlFlags_DI_02_12.
            /// </summary>
            AGCControlFlags_DI_02_12 = 1 << 12,   // 0001 0000  0000 0000

            /// <summary>
            /// Defines the AGCControlFlags_DI_02_13.
            /// </summary>
            AGCControlFlags_DI_02_13 = 1 << 13,   // 0010 0000  0000 0000

            /// <summary>
            /// Defines the AGCControlFlags_DI_02_14.
            /// </summary>
            AGCControlFlags_DI_02_14 = 1 << 14,   // 0100 0000  0000 0000

            /// <summary>
            /// Defines the AGCControlFlags_DI_02_15.
            /// </summary>
            AGCControlFlags_DI_02_15 = 1 << 15,   // 1000 0000  0000 0000

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Course.
        /// </summary>
        public int Course
        {
            get { return course; }
            set { course = value; }
        }

        /// <summary>
        /// Gets or sets the CurrentScreenNumber.
        /// </summary>
        public int CurrentScreenNumber
        {
            get { return currentScreenNumber; }
            set { currentScreenNumber = value; }
        }

        /// <summary>
        /// Gets or sets the FaultStatus.
        /// </summary>
        public int FaultStatus
        {
            get { return faultStatus; }
            set { faultStatus = value; }
        }

        /// <summary>
        /// Gets or sets the LastStation.
        /// </summary>
        public int LastStation
        {
            get { return lastStation; }
            set { lastStation = value; }
        }

        /// <summary>
        /// Gets or sets the NextStation.
        /// </summary>
        public int NextStation
        {
            get { return nextStation; }
            set { nextStation = value; }
        }

        /// <summary>
        /// Gets or sets the SetCourse.
        /// </summary>
        public int SetCourse
        {
            get { return setCourse; }
            set { setCourse = value; }
        }

        /// <summary>
        /// Gets or sets the SetSpeed.
        /// </summary>
        public int SetSpeed
        {
            get { return setSpeed; }
            set { setSpeed = value; }
        }

        /// <summary>
        /// Gets or sets the SetViewA.
        /// </summary>
        public int SetViewA
        {
            get { return setViewA; }
            set { setViewA = value; }
        }

        /// <summary>
        /// Gets or sets the SetViewB.
        /// </summary>
        public int SetViewB
        {
            get { return setViewB; }
            set { setViewB = value; }
        }

        /// <summary>
        /// Gets or sets the Speed.
        /// </summary>
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        /// <summary>
        /// Gets or sets the StationTimeLast.
        /// </summary>
        public int StationTimeLast
        {
            get { return stationTimeLast; }
            set { stationTimeLast = value; }
        }

        /// <summary>
        /// Gets or sets the StationTimer.
        /// </summary>
        public int StationTimer
        {
            get { return stationTimer; }
            set { stationTimer = value; }
        }

        /// <summary>
        /// Gets or sets the Step.
        /// </summary>
        public int Step
        {
            get { return step; }
            set { step = value; }
        }

        /// <summary>
        /// Gets or sets the View_A_Direction.
        /// </summary>
        public int View_A_Direction
        {
            get { return view_A_Direction; }
            set { view_A_Direction = value; }
        }

        /// <summary>
        /// Gets or sets the View_B_Direction.
        /// </summary>
        public int View_B_Direction
        {
            get { return view_B_Direction; }
            set { view_B_Direction = value; }
        }

        /// <summary>
        /// Gets or sets the Voltage.
        /// </summary>
        public int Voltage
        {
            get { return voltage; }
            set { voltage = value; }
        }

        #endregion
    }
}
