using AppSettings;
using System;


namespace CustomEventArgs
{
    public class ScreenPositionEventArgs : EventArgs
    {
        public ScreenPosition Position { get; internal set; }
        public ScreenPositionEventArgs(ScreenPosition position)
        {
            this.Position = position;
        }
    }
}
