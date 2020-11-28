using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using FluentAssertions;
using Xunit;

namespace ValueConverters.Tests
{
    public class ValueConverterGroupTests
    {
        [Theory]
        [ClassData(typeof(ValueConverterGroupValidTestdata))]
        public void ShouldConvert(List<IValueConverter> converters, object value, object parameter, CultureInfo culture, object expectedResult)
        {
            // Arrange
            IValueConverter converter = new ValueConverterGroup
            {
                Converters = converters
            };

            // Act
            var result = converter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [ClassData(typeof(ValueConverterGroupValidTestdata))]
        public void ShouldConvertBack(List<IValueConverter> converters, object value, object parameter, CultureInfo culture, object expectedResult)
        {
            // Arrange
            IValueConverter converter = new ValueConverterGroup
            {
                Converters = converters
            };

            // Act
            var result = converter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class ValueConverterGroupValidTestdata : TheoryData<List<IValueConverter>, object, object, CultureInfo, object>
        {
            public ValueConverterGroupValidTestdata()
            {
                // Empty converters list
                this.Add(null, null, null, CultureInfo.InvariantCulture, null);
                this.Add(new List<IValueConverter>(), null, null, CultureInfo.InvariantCulture, null);
               
                // Sequence of add/subtract converters
                this.Add(new List<IValueConverter> { new AddConverter() }, 10, 20, CultureInfo.InvariantCulture, 30);
                this.Add(new List<IValueConverter> { new AddConverter(), new AddConverter() }, 10, 20, CultureInfo.InvariantCulture, 50);
                this.Add(new List<IValueConverter> { new AddConverter(), new AddConverter(), new SubtractConverter() }, 10, 20, CultureInfo.InvariantCulture, 30);
            }
        }
    }
}
