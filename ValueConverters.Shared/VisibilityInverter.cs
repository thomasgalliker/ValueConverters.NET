﻿#if (NETFX)
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

#if NETFX || NETFX_CORE
namespace ValueConverters
{
    public class VisibilityInverter : BoolToValueConverter<Visibility>
    {
        public VisibilityInverter()
        {
            this.TrueValue = Visibility.Visible;
            this.FalseValue = Visibility.Collapsed;
            this.IsInverted = true;
        }
    }
}
#endif