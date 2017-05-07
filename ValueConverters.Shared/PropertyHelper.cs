using System;
using System.Globalization;

#if XAMARIN
using Xamarin.Forms;
using Property = Xamarin.Forms.BindableProperty;
#else
using Property = System.Windows.DependencyProperty;
#endif

#if NETFX || WINDOWS_PHONE
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

namespace ValueConverters
{
    class PropertyHelper
    {
        public static Property Create<T, TParent>(string name, T defaultValue) =>
#if XAMARIN
            Property.Create(name, typeof(T), typeof(TParent), defaultValue);
#else
            Property.Register(name, typeof(T), typeof(TParent), new PropertyMetadata(defaultValue));
#endif

        public static Property Create<T, TParent>(string name) => Create<T, TParent>(name, default(T));
    }
}
