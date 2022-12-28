using System.Globalization;
using FluentAssertions;
using Xunit;

#if (XAMARIN)
using Xamarin.Forms;
#elif (NET || NETFRAMEWORK)
using System.Windows.Data;
#endif

namespace ValueConverters.Tests
{
    public class SubtractConverterTests
    {
        [Theory]
        [ClassData(typeof(SubtractConverterValidTestdata))]
        public void ShouldSubtractValidInput(object value, object parameter, CultureInfo culture, object expectedResult)
        {
            // Arrange
            IValueConverter converter = new SubtractConverter();

            // Act
            var result = converter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class SubtractConverterValidTestdata : TheoryData<object, object, CultureInfo, object>
        {
            public SubtractConverterValidTestdata()
            {
                // Integer
                this.Add(0, 0, CultureInfo.InvariantCulture, 0);
                this.Add(4, 2, CultureInfo.InvariantCulture, 2);

                // Double
                this.Add(0d, 1.111d, CultureInfo.InvariantCulture, -1.111d);
                this.Add(4.444d, 1.111d, CultureInfo.InvariantCulture, 3.333d);

                // String
                this.Add("4,444", "1,111", new CultureInfo("de-de"), 3.333d);
                this.Add("4.444", "1.111", new CultureInfo("en-us"), 3.333d);
            }
        }

        [Theory]
        [ClassData(typeof(SubtractConverterInvalidTestdata))]
        public void ShouldNotSubtractInvalidInput(object value, object parameter, CultureInfo culture, object expectedResult)
        {
            // Arrange
            IValueConverter converter = new SubtractConverter();

            // Act
            var result = converter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class SubtractConverterInvalidTestdata : TheoryData<object, object, CultureInfo, object>
        {
            public SubtractConverterInvalidTestdata()
            {
                this.Add(null, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
                this.Add("", "", CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
                this.Add("foo", null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
            }
        }
    }
}
