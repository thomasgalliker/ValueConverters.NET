# ValueConverters.NET 
[![Version](https://img.shields.io/nuget/v/ValueConverters.svg)](https://www.nuget.org/packages/ValueConverters)  [![Downloads](https://img.shields.io/nuget/dt/ValueConverters.svg)](https://www.nuget.org/packages/ValueConverters)

This library contains a collection of most commonly used implementations of the IValueConverter interface. ValueConverters are used to convert values bound from the view to the view model - and in some cases also backwards. 

### Download and Install ValueConverters 

This library is available on NuGet: [ https://www.nuget.org/packages/ValueConverters/]( https://www.nuget.org/packages/ValueConverters/)  

Use the following command to install ValueConverters using NuGet package manager console: 

```PM> Install-Package ValueConverters``` 

You can use this library in any .Net project which is compatible to PCL (e.g. Xamarin Android, iOS, Windows Phone, Windows Store, Universal Apps, etc.). There is a special NuGet package for Xamarin.Forms available: 

```PM> Install-Package ValueConverters.Forms``` 

### Supported ValueConverters 

Following table illustrates which converters are supported on the respective platforms: 

<table> 
  <tr> 
    <td>Converter name</td> 
    <td>WPF</td> 
    <td>Windows Phone 8 (SL)</td> 
    <td>Windows Phone 8.1</td> 
    <td>Universal Windows Platform</td> 
    <td>Xamarin Forms</td> 
  </tr> 
  <tr> 
    <td>BoolNegationConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
  </tr> 
  <tr> 
    <td>BoolToBrushConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td></td> 
  </tr> 
  <tr> 
    <td>BoolToDoubleConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
  </tr> 
  <tr> 
    <td>BoolToFontAttributesConverter</td> 
    <td></td> 
    <td></td> 
    <td></td> 
    <td></td> 
    <td>✓</td> 
  </tr> 
  <tr> 
    <td>BoolToFontWeightConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td></td> 
  </tr> 
  <tr> 
    <td>BoolToStringConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
  </tr> 
  <tr> 
    <td>BoolToStyleConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
  </tr> 
  <tr> 
    <td>BoolToThicknessConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
  </tr> 
  <tr> 
    <td>BoolToValueConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
  </tr> 
  <tr> 
    <td>BoolToVisibilityConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td></td> 
  </tr> 
  <tr> 
    <td>DateTimeConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
  </tr> 
  <tr> 
    <td>DebugConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
  </tr> 
  <tr> 
    <td>EnumToBoolConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
  </tr> 
  <tr> 
    <td>EnumToObjectConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
  </tr> 
  <tr> 
    <td>EnumWrapperConverter</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
    <td>✓</td> 
  </tr> 
</table> 


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

### Links 

System.Windows.Data.IValueConverter Interface 

[ https://msdn.microsoft.com/en-us/library/system.windows.data.ivalueconverter(v=vs.110).aspx]( https://msdn.microsoft.com/en-us/library/system.windows.data.ivalueconverter(v=vs.110).aspx)  

Windows.UI.Xaml.Data.IValueConverter interface 

[ https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.data.ivalueconverter]( https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.data.ivalueconverter)  

### License 

CrossPlatformLibrary is Copyright &copy; 2016 [Thomas Galliker]( https://ch.linkedin.com/in/thomasgalliker). Free for non-commercial use. For commercial use please contact the author. 
