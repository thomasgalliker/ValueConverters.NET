using System;
using System.Globalization;

#if XAMARIN
using Xamarin.Forms;
#endif

#if NETFX || NET5_0_OR_GREATER
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

namespace ValueConverters
{
    public class DateTimeConverter : SingletonConverterBase<DateTimeConverter>
    {
        protected const string DefaultFormat = "g";
        protected const string DefaultMinValueString = "";

#if XAMARIN
        public static readonly BindableProperty FormatProperty = BindableProperty.Create(
            nameof(Format),
            typeof(string),
            typeof(DateTimeConverter),
            DefaultFormat);

        public static readonly BindableProperty MinValueStringProperty = BindableProperty.Create(
            nameof(MinValueString),
            typeof(string),
            typeof(DateTimeConverter),
            DefaultMinValueString);
#else
        public static readonly DependencyProperty FormatProperty = DependencyProperty.Register(
            nameof(Format),
            typeof(string),
            typeof(DateTimeConverter),
            new PropertyMetadata(DefaultFormat));

        public static readonly DependencyProperty MinValueStringProperty = DependencyProperty.Register(
            nameof(MinValueString),
            typeof(string),
            typeof(DateTimeConverter),
            new PropertyMetadata(DefaultMinValueString));
#endif

        /// <summary>
        /// The datetime format property.
        /// Standard date and time format strings: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
        /// </summary>
        public string Format
        {
            get => (string)this.GetValue(FormatProperty);
            set => this.SetValue(FormatProperty, value);
        }

        public string MinValueString
        {
            get => (string)this.GetValue(MinValueStringProperty);
            set => this.SetValue(MinValueStringProperty, value);
        }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime == DateTime.MinValue)
                {
                    return this.MinValueString;
                }

                return dateTime.ToLocalTime().ToString(this.Format, culture);
            }

            return UnsetValue;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is DateTime dateTime)
                {
                    return dateTime;
                }

                if (value is string str)
                {
                    DateTime.TryParse(str, out var resultDateTime);
                    return resultDateTime;
                }
            }
            return null;
        }
    }
}
