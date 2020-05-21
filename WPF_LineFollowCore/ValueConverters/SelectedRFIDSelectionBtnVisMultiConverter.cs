namespace ValueConverters
{
    using Models;
    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    /// <summary>
    /// Defines the <see cref="SelectedRFIDSelectionBtnVisMultiConverter" />.
    /// </summary>
    internal class SelectedRFIDSelectionBtnVisMultiConverter : MarkupExtension, IMultiValueConverter
    {
        #region Fields

        //Constructor for the converter
        /// <summary>
        /// Defines the _converter.
        /// </summary>
        private static SelectedRFIDSelectionBtnVisMultiConverter _converter = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedRFIDSelectionBtnVisMultiConverter"/> class.
        /// </summary>
        public SelectedRFIDSelectionBtnVisMultiConverter()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Object array format:
        /// values[0] = (bool) Is Traffic Setup Mode
        /// values[1] = (bool) Is Staging Setup Mode
        /// values[2] = (bool) Is Startlock Setup Mode
        /// values[3] = (RFIDData) The RFID represented by the label
        /// values[4] = (RFIDData) The currently selected RFID.
        /// </summary>
        /// <param name="values">.</param>
        /// <param name="targetType">.</param>
        /// <param name="parameter">.</param>
        /// <param name="culture">.</param>
        /// <returns>.</returns>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if the converter received the correct number of args
            if (values.Length == 5)
            {
                RFIDData RFIDLabelData;
                RFIDData SelectedRFID;
                //store all of the args locally
                bool IsTrafficMode = (bool)values[0];
                bool IsStagingMode = (bool)values[1];
                bool StartLockSetupMode = (bool)values[2];

                if ((values[3] != null) && ((values[3]).GetType() == typeof(RFIDData))) { RFIDLabelData = (RFIDData)values[3]; }
                else { RFIDLabelData = null; }
                if ((values[4] != null) && (values[4].GetType() == typeof(RFIDData))) { SelectedRFID = (RFIDData)values[4]; }
                else { SelectedRFID = null; }


                //Determine color
                //if we are not in the traffic or staging setup mode, or the selected RFID is null, return collapsed
                if (!((IsTrafficMode) || (IsStagingMode) || (StartLockSetupMode)) || (SelectedRFID == null) || (RFIDLabelData == null)) return Visibility.Collapsed;
                else//the user has selected an RFID and we are in one of the two modes
                {
                    //if we are looking at the selected RFID, make it visible
                    if (RFIDLabelData == SelectedRFID) return Visibility.Visible;
                    else return Visibility.Collapsed;
                }
            }
            //if the code gets here, return the collapsed visibility
            return Visibility.Collapsed;
        }

        /// <summary>
        /// The ConvertBack.
        /// </summary>
        /// <param name="value">The value<see cref="object"/>.</param>
        /// <param name="targetTypes">The targetTypes<see cref="Type[]"/>.</param>
        /// <param name="parameter">The parameter<see cref="object"/>.</param>
        /// <param name="culture">The culture<see cref="System.Globalization.CultureInfo"/>.</param>
        /// <returns>The <see cref="object[]"/>.</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("SelectedRFIDSelectionBtnVisMultiConverter is a OneWay converter.");
        }

        /// <summary>
        /// The ProvideValue.
        /// </summary>
        /// <param name="serviceProvider">The serviceProvider<see cref="IServiceProvider"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new SelectedRFIDSelectionBtnVisMultiConverter();
            return _converter;
        }

        #endregion
    }
}
