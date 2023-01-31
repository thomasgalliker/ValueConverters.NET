# ValueConverters.NET 
[![Version](https://img.shields.io/nuget/v/ValueConverters.svg)](https://www.nuget.org/packages/ValueConverters)  [![Downloads](https://img.shields.io/nuget/dt/ValueConverters.svg)](https://www.nuget.org/packages/ValueConverters)

This library contains a collection of most commonly used implementations of the IValueConverter interface. ValueConverters are used to convert values bound from the view to the view model - and in some cases also backwards. 

### Download and Install ValueConverters 

This library is available on NuGet: [ https://www.nuget.org/packages/ValueConverters/]( https://www.nuget.org/packages/ValueConverters/)  

Use the following command to install ValueConverters using NuGet package manager console: 

```PM> Install-Package ValueConverters``` 

If your target platform is Xamarin.Forms use following NuGet package: 

```PM> Install-Package ValueConverters.Forms``` 

If your target platform is .NET MAUI use following NuGet package: 

```PM> Install-Package ValueConverters.MAUI``` 


### API Usage 

The usage of converters is on all platforms more or less the same: 
* Define the converter in the resources area of the view/page/usercontrol. 
* Use the converter in a binding by referenceing  it as a StaticResource. 

#### General Usage of Converters in XAML 

Define a converter in the Resources section of a UserControl, Window, Page, etc. Specify options if required. 

```xml 

 <UserControl.Resources> 
        <ResourceDictionary> 
            <converters:DateTimeConverter x:Key="DateTimeConverter" Format="d" MinValueString="-"/> 
        </ResourceDictionary> 
    </UserControl.Resources> 

``` 

Apply the converter as a StaticResource: 

```xml 

<TextBox Text="{Binding EmployeeDetailViewModel.Birthdate, Converter={StaticResource DateTimeConverter}}"/> 

``` 

#### Using EnumWrapperConverter 

EnumWrapperConverter is used to display localized enums. The concept is fairly simple: Enums are annotated with localized string resources and wrapped into EnumWrapper<TEnumType>. The view uses the EnumWrapperConverter to extract the localized
string resource from the resx file. Following step-by-step instructions show how to localize and bind a simple enum type in a WPF view: 

1) Define new public enum type and annotate enum values with [Display] attributes: 

```cs 

    [DataContract] 
    public enum PartyMode 
    { 
        [EnumMember] 
        [Display(Name = "PartyMode_Off", ResourceType = typeof(PartyModeResources))] 
        Off, 

        // … 
    } 
``` 

3) Create StringResources.resx and define strings with appropriate keys (e.g. "PartyMode__Off"). Make sure PublicResXFileCodeGenerator is used to generate the .Designer.cs file. (If ResXFileCodeGenerator is used, the resource lookup operations may require more time to complete).

4) Create StringResources.resx for other languages (e.g. StringResources.de.resx) and translate all strings accordingly. Use [Multilingual App Toolkit]( https://visualstudiogallery.msdn.microsoft.com/6dab9154-a7e1-46e4-bbfa-18b5e81df520) 
for easy localization of the defined string resources. 

5) Expose enum property in the ViewModel. 

```cs 

        public PartyMode PartyMode 
        { 
            get { return this.partyMode; } 

            set { this.partyMode = value; 
                  this.OnPropertyChanged(() => this.PartyMode); } 
        } 

``` 

6) Bind to enum property in the View and define Converter={StaticResource EnumWrapperConverter}. 

```xml 

        <Label Content="{Binding PartyMode, Converter={StaticResource EnumWrapperConverter}}" /> 

``` 

That’s it. If you want to change the UI language at runtime, don’t forget to call OnPropertyChanged after changing CurrentUICulture. There is a WPF sample app available. 

### Converter Culture
Value converters are culture-aware. Both the Convert and ConvertBack methods have a culture parameter that indicates the cultural information. If cultural information is irrelevant to the conversion, then you can ignore that parameter in your custom converter.

By default, the culture parameter is provided by the underlaying platform. If you want to override the provided culture, use the property PreferredCulture. You can select from one of the following override behaviors:
- **PreferredCulture.ConverterCulture**: Default, uses the converter culture provided by the underlying platform.
- **ConverterCulture.CurrentCulture**: Overrides the default converter culture with CultureInfo.CurrentCulture.
- **ConverterCulture.CurrentUICulture**: Overrides the default converter culture with CultureInfo.CurrentUICulture.

This is particularly helpful in WPF applications, since it is a known/unresolved bug that the provided culture parameter does not update when CultureInfo.CurrentCulture or CultureInfo.CurrentUICulture is updated.
Use **ValueConvertersConfig.DefaultPreferredCulture** to configure the default converter culture for all converters.
 
### Links 

- System.Windows.Data.IValueConverter Interface
[ https://msdn.microsoft.com/en-us/library/system.windows.data.ivalueconverter(v=vs.110).aspx]( https://msdn.microsoft.com/en-us/library/system.windows.data.ivalueconverter(v=vs.110).aspx)  

- Windows.UI.Xaml.Data.IValueConverter interface:
[ https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.data.ivalueconverter]( https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.data.ivalueconverter)  

### License 
ValueConverters.NET is Copyright &copy; 2021 [Thomas Galliker]( https://ch.linkedin.com/in/thomasgalliker). Free for non-commercial use. For commercial use please contact the author. 
