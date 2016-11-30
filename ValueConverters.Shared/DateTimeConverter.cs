#if XAMARIN
using Xamarin.Forms;
#endif

#if NETFX || WINDOWS_PHONE
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

namespace ValueConverters
{
    public class DateTimeConverter : DateTimeConverterBase<DateTimeConverter>
    {
        #if XAMARIN
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
#else
        public static readonly DependencyProperty FormatProperty = DependencyProperty.Register(
            "Format",
            typeof(string),
            typeof(DateTimeConverter),
            new PropertyMetadata(DefaultFormat));

        public static readonly DependencyProperty MinValueStringProperty = DependencyProperty.Register(
            "MinValueString",
            typeof(string),
            typeof(DateTimeConverter),
            new PropertyMetadata(DefaultMinValueString));
#endif

        /// <summary>
        ///     The datetime format property.
        ///     Check MSDN for information about predefined datetime formats:
        ///     http://msdn.microsoft.com/en-us/library/362btx8f(v=vs.90).aspx.
        /// </summary>
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
