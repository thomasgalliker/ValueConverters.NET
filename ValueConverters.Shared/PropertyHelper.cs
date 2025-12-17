using System;
using System.Globalization;

#if (NETFX || NETWPF)
using System.Windows;
using System.Windows.Data;
using Property = System.Windows.DependencyProperty;

#elif (NETFX_CORE)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Property = Windows.UI.Xaml.DependencyProperty;

#elif (XAMARIN)
using Xamarin.Forms;
using Property = Xamarin.Forms.BindableProperty;

#elif (MAUI)
using Microsoft.Maui;
using Property = Microsoft.Maui.Controls.BindableProperty;
#endif

namespace ValueConverters
{
    static class PropertyHelper
    {
        public static Property Create<T, TParent>(string name, T? defaultValue) =>
#if XAMARIN || MAUI
            Property.Create(name, typeof(T), typeof(TParent), defaultValue);
#else
            Property.Register(name, typeof(T), typeof(TParent), new PropertyMetadata(defaultValue));
#endif

        public static Property Create<T, TParent>(string name) => Create<T, TParent>(name, default);
    }
}
