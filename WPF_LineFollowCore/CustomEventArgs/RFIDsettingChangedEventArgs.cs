using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventArgs
{
   public class RFIDsettingChangedEventArgs:System.EventArgs
    {
         public  ObservableCollection<RFIDData> rfids { get; internal set; }

         public RFIDsettingChangedEventArgs(ObservableCollection<RFIDData> rfids)
        {
            this.rfids = rfids;
        }
    }
}
