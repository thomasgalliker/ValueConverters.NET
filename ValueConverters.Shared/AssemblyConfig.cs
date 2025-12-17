using System.Runtime.CompilerServices;
#if (NETWPF || NETFX)
using System.Windows.Markup;

#elif WINDOWS_UWP || UWP
using Windows.UI.Xaml.Markup;

#elif MAUI
using XmlnsPrefixAttribute = Microsoft.Maui.Controls.XmlnsPrefixAttribute;
#endif

[assembly: InternalsVisibleTo("ValueConverters.Netfx.Tests")]
[assembly: InternalsVisibleTo("ValueConverters.WPF.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

#if MAUI || NETWPF || NETFX
[assembly: XmlnsPrefix("http://schemas.superdev.ch/valueconverters/2016/xaml", "c")]
#endif

#if MAUI || NETWPF || NETFX
[assembly: XmlnsDefinition("http://schemas.superdev.ch/valueconverters/2016/xaml", "ValueConverters")]
#endif