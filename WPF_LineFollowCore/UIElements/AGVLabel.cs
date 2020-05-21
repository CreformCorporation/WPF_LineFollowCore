namespace UIElements
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Defines the <see cref="AGVLabel" />.
    /// </summary>
    internal class AGVLabel : Label
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AGVLabel"/> class.
        /// </summary>
        public AGVLabel()
        {
            FontWeight = FontWeights.Bold;
            Width = Double.NaN;
            Height = Double.NaN;
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;
            HorizontalContentAlignment = HorizontalAlignment.Center;
            VerticalContentAlignment = VerticalAlignment.Center;
            Padding = new Thickness(3, 0, 3, 0);
        }

        #endregion
    }
}
