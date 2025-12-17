using System.Globalization;
using FluentAssertions;
using Xunit;

#if(XAMARIN)
using Xamarin.Forms;
#elif (NET || NETFRAMEWORK)
using System.Windows.Data;
#endif


namespace ValueConverters.Tests
{
    public class AddConverterTests
    {
        [Theory]
        [ClassData(typeof(AddConverterValidTestdata))]
        public void ShouldAddValidInput(object ?value, object? parameter, CultureInfo? culture, object? expectedResult)
        {
            // Arrange
            IValueConverter converter = new AddConverter();

            // Act
            var result = converter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class AddConverterValidTestdata : TheoryData<object?, object?, CultureInfo?, object?>
        {
            public AddConverterValidTestdata()
            {
                // Integer
                this.Add(0, 0, CultureInfo.InvariantCulture, 0);
                this.Add(1, 1, CultureInfo.InvariantCulture, 2);

                // Double
                this.Add(0d, 1.111d, CultureInfo.InvariantCulture, 1.111d);
                this.Add(4.444d, 1.111d, CultureInfo.InvariantCulture, 5.555d);

                // String
                this.Add("4,444", "1,111", new CultureInfo("de-de"), 5.555d);
                this.Add("4.444", "1.111", new CultureInfo("en-us"), 5.555d);
            }
        }

        [Theory]
        [ClassData(typeof(AddConverterInvalidTestdata))]
        public void ShouldNotAddInvalidInput(object? value, object? parameter, CultureInfo? culture, object? expectedResult)
        {
            // Arrange
            IValueConverter converter = new AddConverter();

            // Act
            var result = converter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class AddConverterInvalidTestdata : TheoryData<object?, object?, CultureInfo?, object?>
        {
            public AddConverterInvalidTestdata()
            {
                this.Add(null, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
                this.Add("", "", CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
                this.Add("foo", null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
            }
        }
    }
}
