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
	<tbody>
		<tr>
			<td>&nbsp;</td>
			<td colspan="4" rowspan="1" style="text-align:center">Platform</td>
		</tr>
		<tr>
			<td>Converter</td>
			<td>WPF (.NET Framework)</td>
			<td>WPF (.NET)</td>
			<td>Universal Windows Platform</td>
			<td>Xamarin Forms</td>
		</tr>
		<tr>
			<td><p>BoolNegationConverter<br />
			Inverts the bool value true to false and vice versa.</p>
			</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
		</tr>
		<tr>
			<td><p>BoolToBrushConverter<br />
			Converts a bool value to a Brush.</p>
			</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td><p>BoolToDoubleConverter<br />
			Converts a bool value to double.</p>
			</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
		</tr>
		<tr>
			<td>BoolToFontAttributesConverter</td>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
			<td>✓</td>
		</tr>
		<tr>
			<td>BoolToFontWeightConverter</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>BoolToStringConverter</td>
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
		</tr>
		<tr>
			<td>BoolToThicknessConverter</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
		</tr>
		<tr>
			<td><strong>BoolToValueConverter</strong><br />
			This is a generic converter used to convert any bool value to a target value of any type. TrueValue is returned for bool &quot;true&quot; and FalseValue is return for bool &quot;false&quot;.</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
		</tr>
		<tr>
			<td><strong>BoolToVisibilityConverter</strong><br />
			Converts a bool value to Visibility.Collapsed (false) and Visibility.Visible (true).</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td><strong>DateTimeConverter</strong><br />
			Converts DateTime values to string using given Format. If the value is DateTime.MinValue, the configured&nbsp;MinValueString is returned.</td>
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
		</tr>
		<tr>
			<td>EnumToBoolConverter</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
			<td>✓</td>
		</tr>
		<tr>
			<td>EnumToObjectConverter<br />
			Maps a resource dictionary of enum keys to objects. This converter is useful to map enums to (localized) strings or images.</td>
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
		</tr>
	</tbody>
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
