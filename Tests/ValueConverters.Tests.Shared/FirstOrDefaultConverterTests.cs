using System;
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
    public class FirstOrDefaultConverterTests
    {
        [Theory]
        [ClassData(typeof(FirstOrDefaultConverterTestdata))]
        public void ShouldConvert(object value, object parameter, CultureInfo culture, object expectedResult)
        {
            // Arrange
            IValueConverter converter = new FirstOrDefaultConverter();

            // Act
            var result = converter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class FirstOrDefaultConverterTestdata : TheoryData<object, object, CultureInfo, object>
        {
            public FirstOrDefaultConverterTestdata()
            {
                // Input is not IEnumerable
                this.Add(0, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);

                // Input is an empty IEnumerable
                this.Add(new object[] { }, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);

                // Input is an array
                this.Add(new[] { 1, 2, 3 }, null, CultureInfo.InvariantCulture, 1);
            }
        }

        [Fact]
        public void ShouldThrowNotSupportedExceptionOnConvertBack()
        {
            // Arrange
            IValueConverter converter = new FirstOrDefaultConverter();

            const bool InutValue = true;

            // Act
            Action action = () => converter.ConvertBack(InutValue, null, null, null);

            // Assert
            action.Should().Throw<NotSupportedException>();
        }
    }
}
