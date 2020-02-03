using System;
using System.Globalization;
using System.Windows.Data;
using FluentAssertions;
using Xunit;

namespace ValueConverters.Tests
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
            Assert.Equal(expectedValue, convertedOutput);
        }

        [Fact]
        public void ShouldConvertBack()
        {
            // Arrange
            IValueConverter dateTimeConverter = new DateTimeConverter();
            DateTime dateTimeNow = DateTime.Now;
            string dateTimeInput = dateTimeNow.ToLongTimeString();

            // Act
            var convertedOutput = (DateTime)dateTimeConverter.ConvertBack(dateTimeInput, null, null, null);

            // Assert
            (dateTimeNow - convertedOutput).Should().BeLessThan(new TimeSpan(0, 0, 0, 1));
        }
    }
}
