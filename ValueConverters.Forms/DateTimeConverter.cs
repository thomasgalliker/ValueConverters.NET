using System;
using System.Globalization;

using Xamarin.Forms;

#if NETFX || WINDOWS_PHONE
using System.Windows;
using System.Windows.Data;
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#endif

namespace ValueConverters
{
    public class DateTimeConverter : DateTimeConverterBase
    {
        /// <summary>
        ///     The datetime format property.
        ///     Check MSDN for information about predefined datetime formats:
        ///     http://msdn.microsoft.com/en-us/library/362btx8f(v=vs.90).aspx.
        /// </summary>
        public static readonly BindableProperty FormatProperty = BindableProperty.Create(
            "Format",
            typeof(string),
            typeof(DateTimeConverter),
            DefaultFormat);

        public static readonly BindableProperty MinValueStringProperty = BindableProperty.Create(
            "MinValueString",
            typeof(string),
            typeof(DateTimeConverter),
            DefaultMinValueString);

        public override string Format
        {
            get
            {
                return (string)this.GetValue(FormatProperty);
            }
            set
            {
                this.SetValue(FormatProperty, value);
            }
        }

        public override string MinValueString
        {
            get
            {
                return (string)this.GetValue(MinValueStringProperty);
            }
            set
            {
                this.SetValue(MinValueStringProperty, value);
            }
        }
    }
}