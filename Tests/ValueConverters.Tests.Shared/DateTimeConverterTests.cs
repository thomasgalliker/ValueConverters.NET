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
    public class DateTimeConverterTests
    {
        private const string DefaultFormat = "g";

        [Theory]
        [ClassData(typeof(DateTimeConverterTestsValidTestdata))]
        public void ShouldConvert(object value, object parameter, CultureInfo culture, object expectedResult)
        {
            // Arrange
            IValueConverter dateTimeConverter = new DateTimeConverter
            {
                Format = DefaultFormat,
                MinValueString = "-",
            };

            // Act
            var result = dateTimeConverter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class DateTimeConverterTestsValidTestdata : TheoryData<object, object, CultureInfo, object>
        {
            public DateTimeConverterTestsValidTestdata()
            {
                this.Add(null, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
                this.Add(DateTime.MinValue, null, CultureInfo.InvariantCulture, "-");
                this.Add(new DateTime(2014, 8, 26, 18, 0, 0), null, CultureInfo.InvariantCulture, "08/26/2014 20:00");
            }
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
