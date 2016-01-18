using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace ValueConverters
{
    /// <summary>
    /// Source: http://stackoverflow.com/questions/2787725/how-to-display-different-enum-icons-using-xaml-only
    /// </summary>
    [ContentProperty("Items")]
    public class EnumToObjectConverter : ConverterBase
    {
        public ResourceDictionary Items { get; set; }

        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }

            string key = Enum.GetName(value.GetType(), value);
            if (this.Items != null && this.Items.Contains(key))
            {
                return this.Items[key];
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
