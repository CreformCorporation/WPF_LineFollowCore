using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVINUMonitor.CustomEventArgs
{
    public class SettingsEventArgs : System.EventArgs
    {
        public int loggingLevel;
        public SettingsEventArgs(int loggingLevel)
        {
            this.loggingLevel = loggingLevel;
        }
    }
}
