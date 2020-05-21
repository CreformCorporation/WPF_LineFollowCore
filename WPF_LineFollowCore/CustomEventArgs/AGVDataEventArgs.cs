using AGV_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventArgs
{
    public class AGVDataEventArgs : System.EventArgs
    {
        public AGVData AGV { get; internal set; }
        public AGVDataEventArgs(AGVData agv)
        {
            this.AGV = agv;
        }
    }
}
