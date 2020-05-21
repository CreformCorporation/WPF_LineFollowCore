using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSettings
{
    public class UserSettings : BindableBase
    {
        private ScreenPosition _lastState = new ScreenPosition();
        public ScreenPosition LastState
        {
            get { return _lastState; }
            set
            {
                 SetProperty(ref _lastState, value);
            }
        }

        public ObservableCollection<ScreenPosition> SavedScreenConfigurations = new ObservableCollection<ScreenPosition>();

    }
}
