using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventArgs
{
    public class ErrorEventArgs : EventArgs
    {
        public string exceptionMessage;
        public string programmerErrorMsg;
        public string stackTrace;

        public ErrorEventArgs(String programmerError)
        {
            this.programmerErrorMsg = programmerError;
        }

        public ErrorEventArgs(String programmerError, String exceptionMsg, String stackTrace)
        {
            this.programmerErrorMsg = programmerError;
            this.exceptionMessage = exceptionMsg;
            this.stackTrace = stackTrace;
        }
    }
}
