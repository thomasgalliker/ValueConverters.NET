# ValueConverters.NET 

This library contains a collection of most commonly used IValueConverters. Following table illustrates which converters are supported on the respective platforms: 

<table> 
  <tr> 
    <td></td> 
    <td>Supported platforms</td> 
    <td></td> 
    <td></td> 
    <td></td> 
    <td></td> 
  </tr> 
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
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>BoolToBrushConverter</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>BoolToDoubleConverter</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>BoolToFontWeightConverter</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>BoolToStringConverter</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>BoolToStyleConverter</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>BoolToThicknessConverter</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>BoolToValueConverter</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>BoolToVisibilityConverter</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>DateTimeConverter</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>DebugConverter</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>EnumToBoolConverter</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>EnumToObjectConverter</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
  <tr> 
    <td>EnumWrapperConverter</td> 
    <td>yes</td> 
    <td>planned</td> 
    <td>planned</td> 
    <td>planned</td> 
    <td>planned</td> 
  </tr> 
</table> 


### Download and Install ValueConverters 

This library is available on NuGet: [ https://www.nuget.org/packages/ValueConverters/]( https://www.nuget.org/packages/ValueConverters/)  

Use the following command to install ValueConverters using NuGet package manager console: 

```PM> Install-Package ValueConverters``` 

You can use this library in any .Net project which is compatible to PCL (e.g. Xamarin Android, iOS, Windows Phone, Windows Store, Universal Apps, etc.). There is a special NuGet package for Xamarin.Forms available: 

```PM> Install-Package ValueConverters.Forms``` 

### API Usage 

The usage of converters is on all platforms more or less the same: 

* Define the converter in the resources area of the view/page/usercontrol. 

* Use the converter in a binding by referenceing  it as a StaticResource. 

#### WPF example 

Define a converter in the Resources section of a UserControl. Specify options if required. 

```xaml 

 <UserControl.Resources> 

        <ResourceDictionary> 

            <converters:DateTimeConverter x:Key="DateTimeConverter" Format="d" MinValueString="-"/> 

        </ResourceDictionary> 

    </UserControl.Resources> 

``` 

Apply the converter as a StaticResource: 

```xaml 

<TextBox Text="{Binding EmployeeDetailViewModel.Birthdate, Converter={StaticResource DateTimeConverter}}"/> 

``` 

### Links 

System.Windows.Data.IValueConverter Interface 

[ https://msdn.microsoft.com/en-us/library/system.windows.data.ivalueconverter(v=vs.110).aspx]( https://msdn.microsoft.com/en-us/library/system.windows.data.ivalueconverter(v=vs.110).aspx)  

Windows.UI.Xaml.Data.IValueConverter interface 

[ https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.data.ivalueconverter]( https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.data.ivalueconverter)  

### License 

CrossPlatformLibrary is Copyright &copy; 2016 [Thomas Galliker]( https://ch.linkedin.com/in/thomasgalliker). Free for non-commercial use. For commercial use please contact the author. 
