using System;
using System.Globalization;
using System.Windows.Data;

using Xunit;

namespace ValueConverters.NetFx.Tests
{
    public class DateTimeConverterTests
    {
        private const string DefaultFormat = "g";

        [Fact]
        public void ShouldConvert()
        {
            // Arrange
            IValueConverter dateTimeConverter = new DateTimeConverter();

            var input = new DateTime(2014, 8, 26, 18, 0, 0);
            var expectedValue = (input).ToLocalTime().ToString(DefaultFormat, CultureInfo.CurrentUICulture);
            
            // Act
            var convertedOutput = dateTimeConverter.Convert(input, typeof(string), null, CultureInfo.CurrentUICulture);

            // Assert
            Assert.Equal(convertedOutput, expectedValue);
        }

        [Fact]
        public void ShouldNotConvertBecauseOfWrongTargetType()
        {
            // Arrange
            IValueConverter dateTimeConverter = new DateTimeConverter();

            var input = new DateTime(2014, 8, 26, 18, 0, 0);
            var expectedValue = (input).ToLocalTime().ToString(DefaultFormat, CultureInfo.CurrentUICulture);

            // Act
            var convertedOutput = dateTimeConverter.Convert(input, typeof(object), null, CultureInfo.CurrentUICulture);

            // Assert
            Assert.NotEqual(convertedOutput, expectedValue);
        }

        [Fact]
        public void ShouldThrowNotSupportedExceptionOnConvertBack()
        {
            // Arrange
            IValueConverter dateTimeConverter = new DateTimeConverter();

            // Act
            Action action = () => dateTimeConverter.ConvertBack(null, null, null, null);

            // Assert
            Assert.Throws<NotSupportedException>(action);
        }
    }
}
