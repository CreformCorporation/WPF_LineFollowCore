namespace Constants
{
    using System;

    /// <summary>
    /// Defines the <see cref="Constants" />.
    /// </summary>
    public class Constants
    {
        #region Fields

        /// <summary>
        /// Defines the NSI_FaultList.
        /// </summary>
        public static readonly string[] NSI_FaultList =
        {
            "No Error", //Fault 0
            "Undefined", //Fault 1
            "Undefined", //Fault 2
            "Undefined", //Fault 3
             "Undefined", //Fault 4
            "Undefined", //Fault 5
            "Undefined", //Fault 6
             "Undefined", //Fault 7
            "Undefined", //Fault 8
            "Undefined", //Fault 9
            "Undefined", //Fault 10
             "Undefined", //Fault 11
             "Undefined", //Fault 12
             "Undefined", //Fault 13
             "Undefined", //Fault 14
             "Undefined", //Fault 15
            "Undefined", //Fault 16
             "Undefined", //Fault 17
             "Undefined", //Fault 18
             "Undefined", //Fault 19
           "Undefined", //Fault 20
            "Undefined", //Fault 21
            "Undefined", //Fault 22
            "Undefined", //Fault 23
            "Undefined", //Fault 24
            "Undefined", //Fault 25
            "Undefined", //Fault 26
            "Undefined", //Fault 27
            "Undefined", //Fault 28
            "Undefined", //Fault 29
            "Undefined", //Fault 30
            "Undefined", //Fault 31
            "Undefined", //Fault 32
            "Undefined", //Fault 33
            "Undefined", //Fault 34
            "Undefined", //Fault 35
            "Undefined", //Fault 36
            "Undefined", //Fault 37
            "Undefined", //Fault 38
            "Undefined", //Fault 39
            "Undefined", //Fault 40
            "Undefined", //Fault 41
            "Undefined", //Fault 42
            "Undefined", //Fault 43
            "Undefined", //Fault 44
            "Undefined", //Fault 45
            "Undefined", //Fault 46
            "Undefined", //Fault 47
                    "Undefined", //Fault 48
            "Undefined", //Fault 49
            "Undefined", //Fault 50
            "Undefined", //Fault 51
            "Undefined", //Fault 52
            "Undefined", //Fault 53
            "Undefined", //Fault 54
            "Undefined", //Fault 55
            "Undefined", //Fault 56
            "Undefined", //Fault 57
            "Undefined", //Fault 58
            "Undefined", //Fault 59
            "Undefined", //Fault 60
            "Undefined", //Fault 61
            "Undefined", //Fault 62
            "Undefined", //Fault 63
            "Undefined", //Fault 64
            "Undefined", //Fault 65
            "Undefined", //Fault 66
            "Undefined", //Fault 67
            "Undefined", //Fault 68
            "Undefined", //Fault 69
            "Undefined", //Fault 70
            "Undefined", //Fault 71
            "Undefined", //Fault 72
            "Undefined", //Fault 73
            "Undefined", //Fault 74
            "Undefined", //Fault 75
            "Undefined", //Fault 76
            "Undefined", //Fault 77
            "Undefined", //Fault 78
            "Undefined", //Fault 79
            "Undefined", //Fault 80
            "Undefined", //Fault 81
            "Undefined", //Fault 82
            "Undefined", //Fault 83
            "Undefined", //Fault 84
            "Undefined", //Fault 85
            "Undefined", //Fault 86
            "Undefined", //Fault 87
            "Undefined", //Fault 88
            "Undefined", //Fault 89
            "Undefined", //Fault 90
            "Undefined", //Fault 91
            "Undefined", //Fault 92
            "Undefined", //Fault 93
            "Undefined", //Fault 94
            "Undefined", //Fault 95
            "Undefined", //Fault 96
            "Undefined", //Fault 97
            "Undefined", //Fault 98
            "Undefined" //Fault 99
        };

        #endregion

        #region Enums

        /// <summary>
        /// Defines the AGVStatus.
        /// </summary>
        [Flags]
        public enum AGVStatus
        {
            /// <summary>
            /// Defines the None.
            /// </summary>
            None = 0,

            /// <summary>
            /// Defines the Disconnected.
            /// </summary>
            Disconnected = 1,

            /// <summary>
            /// Defines the Moving.
            /// </summary>
            Moving = 2,

            /// <summary>
            /// Defines the Stopped.
            /// </summary>
            Stopped = 4,

            /// <summary>
            /// Defines the LaserStopped.
            /// </summary>
            LaserStopped = 8,

            /// <summary>
            /// Defines the MasterOn.
            /// </summary>
            MasterOn = 16,

            /// <summary>
            /// Defines the Faulted.
            /// </summary>
            Faulted = 32,

            /// <summary>
            /// Defines the LowVoltage.
            /// </summary>
            LowVoltage = 64
        }

        public enum AGVType
        {
            Unspecified = 0,//default enum value
            NSI = 1,  //uses Rodent class
        }
            #endregion
        }
    }
