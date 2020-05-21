namespace AGV.Main.AGVClasses
{
    using System;
    using System.Collections;

    /// <summary>
    /// Defines the <see cref="AGVBinaries" />.
    /// </summary>
    public class AGVBinaries
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AGVBinaries"/> class.
        /// </summary>
        public AGVBinaries()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the AGV_Enable.
        /// </summary>
        public object AGV_Enable { get; private set; }

        /// <summary>
        /// Gets a value indicating whether AutoMode.
        /// 400002.02...
        /// </summary>
        public bool AutoMode { get; private set; }

        /// <summary>
        /// Gets a value indicating whether ChargeStatus.
        /// 400001.11...
        /// </summary>
        public bool ChargeStatus { get; private set; }

        /// <summary>
        /// Gets a value indicating whether ControlClear.
        /// 400002.00...
        /// </summary>
        public bool ControlClear { get; private set; }

        /// <summary>
        /// Gets a value indicating whether ControlOff.
        /// 400002.03...
        /// </summary>
        public bool ControlOff { get; private set; }

        /// <summary>
        /// Gets a value indicating whether Direction.
        /// 400001.14...
        /// </summary>
        public bool Direction { get; private set; }

        /// <summary>
        /// Gets a value indicating whether Fault.
        /// 400001.08...
        /// </summary>
        public bool Fault { get; private set; }

        /// <summary>
        /// Gets a value indicating whether FollowLeft.
        /// 400001.05...
        /// </summary>
        public bool FollowLeft { get; private set; }

        /// <summary>
        /// Gets a value indicating whether FollowRight.
        /// 400001.04...
        /// </summary>
        public bool FollowRight { get; private set; }

        /// <summary>
        /// Gets a value indicating whether MasterOn.
        /// 400001.10...
        /// </summary>
        public bool MasterOn { get; private set; }

        /// <summary>
        /// Gets a value indicating whether OnPath.
        /// 400001.06...
        /// </summary>
        public bool OnPath { get; private set; }

        /// <summary>
        /// Gets a value indicating whether OverrideTC.
        /// 400001.15...
        /// </summary>
        public bool OverrideTC { get; private set; }

        /// <summary>
        /// Gets a value indicating whether PinDn.
        /// 400001.03...
        /// </summary>
        public bool PinDn { get; private set; }

        /// <summary>
        /// Gets a value indicating whether PinUp.
        /// 400001.02...
        /// </summary>
        public bool PinUp { get; private set; }

        /// <summary>
        /// Gets a value indicating whether Present.
        /// 400001.07...
        /// </summary>
        public bool Present { get; private set; }

        /// <summary>
        /// Gets the PulseSignal.
        /// </summary>
        public object PulseSignal { get; private set; }

        /// <summary>
        /// Gets a value indicating whether ResetPB.
        /// 400002.06...
        /// </summary>
        public bool ResetPB { get; private set; }

        /// <summary>
        /// Gets a value indicating whether RunMode.
        /// 400001.13...
        /// </summary>
        public bool RunMode { get; private set; }

        /// <summary>
        /// Gets a value indicating whether StartAuxilary.
        /// 400001.12...
        /// </summary>
        public bool StartAuxilary { get; private set; }

        /// <summary>
        /// Gets a value indicating whether StartPB.
        /// 400002.04...
        /// </summary>
        public bool StartPB { get; private set; }

        /// <summary>
        /// Gets a value indicating whether StartPBAlarm.
        /// 400002.07...
        /// </summary>
        public bool StartPBAlarm { get; private set; }

        /// <summary>
        /// Gets a value indicating whether StopOverrideStatus.
        /// 400001.09...
        /// </summary>
        public bool StopOverrideStatus { get; private set; }

        /// <summary>
        /// Gets a value indicating whether StopPB.
        /// 400002.05...
        /// </summary>
        public bool StopPB { get; private set; }

        /// <summary>
        /// Gets the TC_SignalOn.
        /// </summary>
        public object TC_SignalOn { get; private set; }

        /// <summary>
        /// Gets a value indicating whether TempSlow. 
        /// 400001.00...
        /// </summary>
        public bool TempSlow { get; private set; }

        /// <summary>
        /// Gets a value indicating whether TempStop.
        /// 400001.01...
        /// </summary>
        public bool TempStop { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The UpdateBinariesDIO01.
        /// </summary>
        /// <param name="Value">The Value<see cref="ushort"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool UpdateBinaries_DIO_01(ushort Value)
        {
            bool Complete = false;




            BitArray bitArray = new BitArray(BitConverter.GetBytes(Value));
            TempSlow = bitArray[0];
            TempStop = bitArray[1];
            PinUp = bitArray[2];
            PinDn = bitArray[3];
            FollowRight = bitArray[4];
            FollowLeft = bitArray[5];
            OnPath = bitArray[6];
            Present = bitArray[7];
            Fault = bitArray[8];
            StopOverrideStatus = bitArray[9];
            MasterOn = bitArray[10];
            ChargeStatus = bitArray[11];
            RunMode = bitArray[13];
            Direction = bitArray[14];
            OverrideTC = bitArray[15];





            return Complete;
        }

        /// <summary>
        /// The UpdateBinariesDIO02.
        /// </summary>
        /// <param name="Value">The Value<see cref="ushort"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool UpdateBinaries_DIO_02(ushort Value)
        {
            bool Complete = false;
            BitArray bitArray = new BitArray(BitConverter.GetBytes(Value));
            ControlClear = bitArray[0];
            AutoMode = bitArray[2];
            ControlOff = bitArray[3];
            StartPB = bitArray[4];
            StopPB = bitArray[5];
            ResetPB = bitArray[6];
            StartPBAlarm = bitArray[7];
            TC_SignalOn = bitArray[8];
            PulseSignal = bitArray[9];
            AGV_Enable = bitArray[10];


            return Complete;
        }

        #endregion
    }
}
