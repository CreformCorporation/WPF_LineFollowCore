using AGV_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventArgs
{
    public class AGVChangeRFIDEventArgs : System.EventArgs
    {
        public AGVData AGV { get; internal set; }
        public int RFIDNumberRequested { get; internal set; }
        public AGVChangeRFIDEventArgs(AGVData agv, int requestedRFIDnumber)
        {
            this.AGV = agv;
            this.RFIDNumberRequested = requestedRFIDnumber;
        }
    }
}
