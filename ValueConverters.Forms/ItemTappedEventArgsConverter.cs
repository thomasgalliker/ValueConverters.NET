using System;
using System.Globalization;
using Xamarin.Forms;

namespace ValueConverters
{
    public class ItemTappedEventArgsConverter : ConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ItemTappedEventArgs eventArgs))
            {
                throw new ArgumentException("ItemTappedEventArgsConverter expects value to be of type ItemTappedEventArgs", nameof(value));
            }

            return eventArgs.Item;
        }
    }
}
